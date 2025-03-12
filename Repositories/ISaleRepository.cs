using System.Collections.Generic;
using System.Threading.Tasks;
using ITM.VehicleSales.Models;

namespace ITM.VehicleSales.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<Sale> GetSaleByIdAsync(int id);
        Task<Sale> AddSaleAsync(Sale sale);
        Task<IEnumerable<Sale>> GetSalesByCustomerIdAsync(int customerId);
    }
} 