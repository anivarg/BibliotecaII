using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class Editora
    {
        public Editora()
        {
            this.Libro = new HashSet<Libro>();
        }
        [Key]
        public int IdEditoras { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}