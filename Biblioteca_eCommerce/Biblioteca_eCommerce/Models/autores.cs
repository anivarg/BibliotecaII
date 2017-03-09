using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class autores
    {
       // forPulll
        public autores()
        {
            this.Libro = new HashSet<Libro>();
        }
        [Key]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Idioma { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}