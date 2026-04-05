namespace EquipmentRentalApp.Models;

public class Projector : Equipment
{
    public int Lumens { get; set; }

    public string Resolution { get; set; }

    public Projector(int id, string name, int lumens, string resolution)
        : base(id, name)
    {
        Lumens = lumens;
        Resolution = resolution;
    }
}