using System.Collections.Generic;
using System.Threading.Tasks;
using ITM.VehicleSales.Models;
using ITM.VehicleSales.Repositories;

namespace ITM.VehicleSales.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllVehiclesAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(id);
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            return await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            return await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            return await _vehicleRepository.DeleteVehicleAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync()
        {
            return await _vehicleRepository.GetAvailableVehiclesAsync();
        }
    }
} 