using Microsoft.AspNetCore.Http; // Assicurati di aggiungere il namespace per IFormFile
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoComplessoID.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Display(Name = "Titolo")]
        public string? Title { get; set; }

        [Display(Name = "Artista")]
        public string? Band { get; set; }

        [Display(Name = "Data di rilascio")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genere")]
        public string? Genre { get; set; }

        [Display(Name = "Prezzo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Dal vivo")]
        public bool IsLive { get; set; }

        [Display(Name = "Copertina")]

        public string? ImageData { get; set; }

        [Display(Name = "Supporto")]
        public string? Format { get; set; }

        [Display(Name = "Nazione")]
        public string? Nation { get; set; }
    }
}
