using EquipmentRentalApp.Models;
using EquipmentRentalApp.Repositories;
using EquipmentRentalApp.Services;

var equipmentRepo = new EquipmentRepository();
var userRepo = new UserRepository();
var rentalRepo = new RentalRepository();

var rentalService = new RentalService(
    equipmentRepo,
    userRepo,
    rentalRepo
);

Console.WriteLine("=== EQUIPMENT RENTAL APP ===");
Console.WriteLine("=== ADD EQUIPMENT ===");

equipmentRepo.Add(new Laptop(1, "eq1", 10, "Ryzen 5 5700x3d"));
equipmentRepo.Add(new Projector(2, "eq2", 300, "HD"));
equipmentRepo.Add(new Camera(3, "eq3", 50, true));

foreach (var e in rentalService.GetAllEquipment())
{
    Console.WriteLine($"{e.Id} {e.Name} available={e.IsAvailable}");
}

Console.WriteLine("\n=== ADD USERS ===");

userRepo.Add(new Student(1, "Damian", "Kraj"));
userRepo.Add(new Employee(2, "Ewa", "Wrek"));

Console.WriteLine("users added");

Console.WriteLine("\n=== RENT EQUIPMENT ===");

var rental1 = rentalService.RentEquipment(
    rentalId: 1,
    equipmentId: 1,
    userId: 1,
    days: 7
);

Console.WriteLine("laptop rented");

Console.WriteLine("\n=== TRY INVALID RENT ===");

try
{
    rentalService.RentEquipment(
        rentalId: 2,
        equipmentId: 1,
        userId: 2,
        days: 3
    );
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n=== RETURN ON TIME ===");

rentalService.ReturnEquipment(1);

Console.WriteLine("equipment returned");

Console.WriteLine("\n=== CREATE LATE RENTAL ===");

var rental2 = rentalService.RentEquipment(
    rentalId: 3,
    equipmentId: 2,
    userId: 2,
    days: 0
);

Thread.Sleep(2000);

rentalService.ReturnEquipment(3);

Console.WriteLine($"penalty = {rental2.Penalty}");

Console.WriteLine("\n=== REPORT ===");

Console.WriteLine(rentalService.GenerateReport());

Console.WriteLine("=== END ===");