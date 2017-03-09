using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class Usuario
    {
        public Usuario()
        {
            this.Prestamo = new HashSet<Prestamo>();
        }
        [Key]
        public int IdUsuarios { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
   
        [Required(ErrorMessage = "Debe ingresar su apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar una matricula")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "Debe ingresar su correo")]
        [RegularExpression(@"[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Debe especificar que tipo de persona es")]
        public string tipoPersona { get; set; }

        [Required(ErrorMessage = "Debe especificar su contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Debe confirmar su contraseña")]
        [DataType(DataType.Password)]
        public string confimPassword { get; set; }

        public int Estado { get; set; }

        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}