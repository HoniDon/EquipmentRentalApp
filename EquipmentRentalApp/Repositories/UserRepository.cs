using EquipmentRentalApp.Models;

namespace EquipmentRentalApp.Repositories;

public class UserRepository
{
    private readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}