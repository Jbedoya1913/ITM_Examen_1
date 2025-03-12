using System;
using System.Collections.Generic;

namespace ITM.VehicleSales.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        // Relaciones
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        
        // Propiedades de navegación
        public string FullName => $"{FirstName} {LastName}";
    }
} 