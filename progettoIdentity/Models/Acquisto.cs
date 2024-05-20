using System;

namespace ProgettoComplessoID.Models
{
    public class Acquisto
    {
        public int Id { get; set; }
        public DateTime DataAcquisto { get; set; }
        public string? NomeTipo { get; set; }
        public decimal Prezzo { get; set; }
        public string? Cliente { get; set; }
       
    }
}
