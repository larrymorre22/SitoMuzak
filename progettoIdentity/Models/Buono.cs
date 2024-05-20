using System;

namespace ProgettoComplessoID.Models
{
    public class Buono
    {
        public int Id { get; set; }
        public string? Codice { get; set; }
        public decimal Valore { get; set; }
        public DateTime DataScadenza { get; set; }
        
    }
}
