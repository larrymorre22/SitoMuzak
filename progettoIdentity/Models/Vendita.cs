using System;

namespace ProgettoComplessoID.Models
{
    public class Vendita
    {
        public int Id { get; set; }
        public DateTime DataVendita { get; set; }
        public int ProdottoId { get; set; } // ID del prodotto venduto
        public string? NomeTipo { get; set; } // Tipo del prodotto venduto (es. "DVD", "Gadget", etc.)
        public decimal PrezzoVendita { get; set; }
        public string? Cliente { get; set; }
        
    }
}
