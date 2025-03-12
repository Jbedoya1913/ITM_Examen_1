using System.Collections.Generic;
using System.Threading.Tasks;
using ITM.VehicleSales.Models;
using ITM.VehicleSales.Repositories;

namespace ITM.VehicleSales.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public SaleService(ISaleRepository saleRepository, IVehicleRepository vehicleRepository)
        {
            _saleRepository = saleRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _saleRepository.GetAllSalesAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetSaleByIdAsync(id);
        }

        public async Task<Sale> AddSaleAsync(Sale sale)
        {
            // Verificar que el vehículo existe y no está vendido
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(sale.VehicleId);
            if (vehicle == null || vehicle.IsSold)
            {
                return null;
            }

            // Establecer el precio de venta si no se proporciona
            if (sale.SalePrice <= 0)
            {
                sale.SalePrice = vehicle.Price;
            }

            return await _saleRepository.AddSaleAsync(sale);
        }

        public async Task<IEnumerable<Sale>> GetSalesByCustomerIdAsync(int customerId)
        {
            return await _saleRepository.GetSalesByCustomerIdAsync(customerId);
        }
    }
} 