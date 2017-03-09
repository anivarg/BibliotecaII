using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class Idioma
    {
        public Idioma()
        {
            this.Libro = new HashSet<Libro>();
        }
        [Key]
        public int IdIdioma { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}