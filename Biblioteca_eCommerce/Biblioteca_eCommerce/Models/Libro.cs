using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class Libro
    {
        public Libro() {

            this.Prestamo = new HashSet<Prestamo>();
        }

        [Key]
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public int SignatureTopography { get; set; }
        public int ISBN { get; set; }
        public int IdBibliografia { get; set; }
        public int IdAutor { get; set; }
        [DataType(DataType.Date)]
        public DateTime YearPublish { get; set; }
        public int IdEditoras { get; set; }
        public string Ciencia { get; set; }
        public string IdIdioma { get; set; }
        public int estado { get; set; }

        public virtual Bibliografia Bibliografia { get; set; }
        public virtual autores autores { get; set; }
        public virtual Idioma Idioma { get; set; }
        public virtual Editora Editora { get; set; }

        public virtual ICollection<Prestamo> Prestamo { get; set; }

    }
}