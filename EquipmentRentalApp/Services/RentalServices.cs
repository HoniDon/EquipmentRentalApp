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
}