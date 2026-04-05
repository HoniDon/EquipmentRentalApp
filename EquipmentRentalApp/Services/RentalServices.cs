using EquipmentRentalApp.Models;
using EquipmentRentalApp.Repositories;

namespace EquipmentRentalApp.Services;

public class RentalService
{
    private readonly EquipmentRepository _equipmentRepository;
    private readonly UserRepository _userRepository;
    private readonly RentalRepository _rentalRepository;

    public RentalService(
        EquipmentRepository equipmentRepository,
        UserRepository userRepository,
        RentalRepository rentalRepository)
    {
        _equipmentRepository = equipmentRepository;
        _userRepository = userRepository;
        _rentalRepository = rentalRepository;
    }
    
    public Rental RentEquipment(int rentalId, int equipmentId, int userId, int days)
    {
        var equipment = _equipmentRepository.GetById(equipmentId);
        var user = _userRepository.GetById(userId);

        if (equipment == null)
            throw new Exception("Equipment not found");

        if (user == null)
            throw new Exception("User not found");

        if (!equipment.IsAvailable)
            throw new Exception("Equipment is not available");

        var activeRentalsCount = _rentalRepository
            .GetActive()
            .Count(r => r.User.Id == userId);

        if (activeRentalsCount >= user.MaxActiveRentals)
            throw new Exception("User reached rental limit");

        var rental = new Rental(
            rentalId,
            equipment,
            user,
            DateTime.Now,
            DateTime.Now.AddDays(days)
        );

        equipment.IsAvailable = false;

        _rentalRepository.Add(rental);

        return rental;
    }
    
    public void ReturnEquipment(int rentalId)
    {
        var rental = _rentalRepository
            .GetAll()
            .FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
            throw new Exception("Rental not found");

        if (rental.ReturnDate != null)
            throw new Exception("Equipment already returned");

        rental.ReturnDate = DateTime.Now;

        rental.Equipment.IsAvailable = true;

        rental.Penalty = CalculatePenalty(rental);
    }
    
    private decimal CalculatePenalty(Rental rental)
    {
        if (rental.ReturnDate <= rental.DueDate)
            return 0;

        var lateDays = (rental.ReturnDate.Value - rental.DueDate).Days;

        return lateDays * 10; // 10 zł za dzień
    }
    
    public List<Equipment> GetAllEquipment()
    {
        return _equipmentRepository.GetAll();
    }
    
    public List<Equipment> GetAvailableEquipment()
    {
        return _equipmentRepository
            .GetAll()
            .Where(e => e.IsAvailable)
            .ToList();
    }
    
    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        return _rentalRepository
            .GetActive()
            .Where(r => r.User.Id == userId)
            .ToList();
    }
    
    public List<Rental> GetOverdueRentals()
    {
        return _rentalRepository
            .GetActive()
            .Where(r => r.DueDate < DateTime.Now)
            .ToList();
    }
    
    public string GenerateReport()
    {
        var totalEquipment = _equipmentRepository.GetAll().Count;

        var availableEquipment = GetAvailableEquipment().Count;

        var activeRentals = _rentalRepository.GetActive().Count;

        var overdueRentals = GetOverdueRentals().Count;

        return $"""
                EQUIPMENT REPORT

                total equipment: {totalEquipment}

                available equipment: {availableEquipment}

                active rentals: {activeRentals}

                overdue rentals: {overdueRentals}
                """;
    }
}