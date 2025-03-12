using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITM.VehicleSales.Models;
using ITM.VehicleSales.Services;

namespace ITM.VehicleSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SalesController(SaleService saleService)
        {
            _saleService = saleService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return Ok(sales);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesByCustomer(int customerId)
        {
            var sales = await _saleService.GetSalesByCustomerIdAsync(customerId);
            return Ok(sales);
        }

        
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            var createdSale = await _saleService.AddSaleAsync(sale);
            
            if (createdSale == null)
            {
                return BadRequest("El vehículo no existe o ya ha sido vendido.");
            }
            
            return CreatedAtAction(nameof(GetSale), new { id = createdSale.Id }, createdSale);
        }
    }
} 
