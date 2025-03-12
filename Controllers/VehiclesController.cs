using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITM.VehicleSales.Models;
using ITM.VehicleSales.Services;

namespace ITM.VehicleSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // GET: api/Vehicles/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAvailableVehicles()
        {
            var vehicles = await _vehicleService.GetAvailableVehiclesAsync();
            return Ok(vehicles);
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            var createdVehicle = await _vehicleService.AddVehicleAsync(vehicle);
            return CreatedAtAction(nameof(GetVehicle), new { id = createdVehicle.Id }, createdVehicle);
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            var updatedVehicle = await _vehicleService.UpdateVehicleAsync(vehicle);
            
            if (updatedVehicle == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var result = await _vehicleService.DeleteVehicleAsync(id);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 