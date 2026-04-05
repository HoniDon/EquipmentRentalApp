using EquipmentRentalApp.Models;

namespace EquipmentRentalApp.Repositories;

public class EquipmentRepository
{
    private readonly List<Equipment> _equipment = new();

    public void Add(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAll()
    {
        return _equipment;
    }

    public Equipment? GetById(int id)
    {
        return _equipment.FirstOrDefault(e => e.Id == id);
    }
}