namespace EquipmentRentalApp.Models;

public class Student : User
{
    public Student(int id, string firstName, string lastName)
        : base(id, firstName, lastName)
    {
        MaxActiveRentals = 2;
    }
}