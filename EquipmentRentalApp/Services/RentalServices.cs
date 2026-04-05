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
}