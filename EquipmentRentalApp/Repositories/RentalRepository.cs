using EquipmentRentalApp.Models;

namespace EquipmentRentalApp.Repositories;

public class RentalRepository
{
    private readonly List<Rental> _rentals = new();

    public void Add(Rental rental)
    {
        _rentals.Add(rental);
    }

    public List<Rental> GetAll()
    {
        return _rentals;
    }

    public List<Rental> GetActive()
    {
        return _rentals.Where(r => r.ReturnDate == null).ToList();
    }
}