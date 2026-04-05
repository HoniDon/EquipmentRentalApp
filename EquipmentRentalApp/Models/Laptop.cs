namespace EquipmentRentalApp.Models;

public class Laptop : Equipment
{
    public int RamGb { get; set; }

    public string Cpu { get; set; }

    public Laptop(int id, string name, int ramGb, string cpu)
        : base(id, name)
    {
        RamGb = ramGb;
        Cpu = cpu;
    }
}