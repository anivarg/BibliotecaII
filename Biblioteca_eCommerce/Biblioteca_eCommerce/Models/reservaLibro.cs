using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class reservaLibro
    {
        [Key]
        public int IdReserva { get; set; }
        public string IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public virtual Libro Libro { get; set; }
    }
}