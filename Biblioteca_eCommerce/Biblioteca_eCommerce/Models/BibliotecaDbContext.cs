using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca_eCommerce.Models
{
    public class BibliotecaDbContext : DbContext
    {
            public DbSet<autores> autor { get; set; }
            public DbSet<Libro> Libros { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Empleado> Empleados { get; set; }
            public DbSet<Prestamo> Prestamos { get; set; }
            public DbSet<Bibliografia> Bibliografias { get; set; }
            public DbSet<Editora> Editoras { get; set; }
            public DbSet<Idioma> Idiomas { get; set; }
    }
}