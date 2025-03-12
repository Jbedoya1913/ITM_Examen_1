using System;
using System.Collections.Generic;

namespace ITM.VehicleSales.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string VIN { get; set; } = string.Empty;
        public bool IsSold { get; set; } = false;
        
        // Relaciones con llaves foráneas
        public int BrandId { get; set; }
        public int AgencyId { get; set; }
        
        // Propiedades de navegación
        public virtual Brand Brand { get; set; } = null!;
        public virtual Agency Agency { get; set; } = null!;
        public virtual Sale? Sale { get; set; }
    }
} 