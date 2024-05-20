using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoComplessoID.Models
{
    public class Documento
    {
        public int Id { get; set; }

        [DisplayName("Nome e tipo")]
        public string? NomeTipo { get; set; }
        public DateTime Data { get; set; }
        
        public string? FilePDF { get; set; }
    }
}
