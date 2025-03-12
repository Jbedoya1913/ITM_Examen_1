using System;
using System.Collections.Generic;

namespace ITM.VehicleSales.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        
        
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
} 
