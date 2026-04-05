namespace EquipmentRentalApp.Models;

public class Camera : Equipment
{
    public int Megapixels { get; set; }

    public bool HasVideo { get; set; }

    public Camera(int id, string name, int megapixels, bool hasVideo)
        : base(id, name)
    {
        Megapixels = megapixels;
        HasVideo = hasVideo;
    }
}