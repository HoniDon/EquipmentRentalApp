namespace EquipmentRentalApp.Models;

public class Rental
{
    public int Id { get; set; }

    public Equipment Equipment { get; set; }

    public User User { get; set; }

    public DateTime RentDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public decimal Penalty { get; set; }

    public Rental(int id, Equipment equipment, User user, DateTime rentDate, DateTime dueDate)
    {
        Id = id;
        Equipment = equipment;
        User = user;
        RentDate = rentDate;
        DueDate = dueDate;
    }
}