using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class Bibliografia
    {
        public Bibliografia()
        {
            this.Libro = new HashSet<Libro>();
        }
        [Key]
        public int IdBibliografia { get; set; }
        [Required(ErrorMessage ="Debe ingresar la descripcion de la bibliografia")]
        [StringLength(64)]
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}