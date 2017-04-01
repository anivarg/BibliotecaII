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
        [Required(ErrorMessage ="Debe ingresar un autor")]
        [StringLength(24)]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Debe elegir un pais")]
        [StringLength(128)]
        public string Pais { get; set; }
        [Required(ErrorMessage ="Debe especificar un idioma")]
        [StringLength(128)]
        public string Idioma { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}