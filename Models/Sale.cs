using System;

namespace ITM.VehicleSales.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public decimal SalePrice { get; set; }
        
        // Relaciones con llaves foráneas
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        
        // Propiedades de navegación
        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
} 