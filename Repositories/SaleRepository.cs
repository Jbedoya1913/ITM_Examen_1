using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITM.VehicleSales.Data;
using ITM.VehicleSales.Models;

namespace ITM.VehicleSales.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _context.Sales
                .Include(s => s.Vehicle)
                    .ThenInclude(v => v.Brand)
                .Include(s => s.Customer)
                .ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _context.Sales
                .Include(s => s.Vehicle)
                    .ThenInclude(v => v.Brand)
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Sale> AddSaleAsync(Sale sale)
        {
            // Obtener el vehículo para marcarlo como vendido
            var vehicle = await _context.Vehicles.FindAsync(sale.VehicleId);
            if (vehicle != null)
            {
                vehicle.IsSold = true;
                _context.Entry(vehicle).State = EntityState.Modified;
            }

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<IEnumerable<Sale>> GetSalesByCustomerIdAsync(int customerId)
        {
            return await _context.Sales
                .Include(s => s.Vehicle)
                    .ThenInclude(v => v.Brand)
                .Include(s => s.Customer)
                .Where(s => s.CustomerId == customerId)
                .ToListAsync();
        }
    }
} 