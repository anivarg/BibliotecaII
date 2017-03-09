using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }
        [Required(ErrorMessage = "Elija el empleado")]
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage = "Elija el libro")]
        public int IdLibro { get; set; }
        [Required(ErrorMessage = "Elija el usuario")]
        public int IdUsuarios { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPrest { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaDevol { get; set; }
        public float MontoxDia { get; set; }
        public int cantDias { get; set; }
        public string Comentario { get; set; }
        public int estado { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual Libro Libro { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}