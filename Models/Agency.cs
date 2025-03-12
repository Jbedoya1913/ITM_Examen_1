using System;
using System.Collections.Generic;

namespace ITM.VehicleSales.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = "Medellín";
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        // Relaciones
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
} 