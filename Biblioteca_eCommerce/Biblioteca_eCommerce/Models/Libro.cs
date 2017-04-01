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
        [Required(ErrorMessage ="Debe introducir el nombre del libro")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        public int SignatureTopography { get; set; }
        [Required(ErrorMessage ="Debe introducir la ISBN del Libro")]
        [StringLength(14, MinimumLength = 13, ErrorMessage="El ISB Debe ser de 10 a 13 Digitos")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Debe elegir una bibliografia")]
        public int IdBibliografia { get; set; }
        [Required(ErrorMessage = "Debe elegir un autor")]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "Debe elegir la fecha de publicación")]
        [DataType(DataType.Date)]
        public DateTime YearPublish { get; set; }
        [Required(ErrorMessage = "Debe elegir la editora")]
        public int IdEditoras { get; set; }
        [Required(ErrorMessage = "Debe elegir el genero literario")]
        public string Ciencia { get; set; }
        [Required(ErrorMessage = "Debe elegir el idioma")]
        public string IdIdioma { get; set; }
        [Range(0, 1, ErrorMessage = "El ISBN debe contener almenos 10 digitos")]
        public int estado { get; set; }

        public virtual Bibliografia Bibliografia { get; set; }
        public virtual autores autores { get; set; }
        public virtual Idioma Idioma { get; set; }
        public virtual Editora Editora { get; set; }

        public virtual ICollection<Prestamo> Prestamo { get; set; }

    }
}