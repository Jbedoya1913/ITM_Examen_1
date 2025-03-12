using System.Collections.Generic;
using System.Threading.Tasks;
using ITM.VehicleSales.Models;

namespace ITM.VehicleSales.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(int id);
        Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();
    }
} 