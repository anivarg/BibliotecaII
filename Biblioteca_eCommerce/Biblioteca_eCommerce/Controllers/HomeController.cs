using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca_eCommerce.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace Biblioteca_eCommerce.Controllers
{
    public class HomeController : Controller
    {
        private BibliotecaDbContext db = new BibliotecaDbContext();

        public ActionResult Index(string Criterio = null)
        {
            var libros = db.Libros.Where(p => Criterio == null || p.Nombre.StartsWith(Criterio)).Include(l => l.autores).Include(l => l.Bibliografia).Include(l => l.Editora);
            return View(libros.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
   
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Reservar(FormCollection form)
        {
            var IdLibro = form["IdLibro"];
            var IdUser = form["IdUsuario"];
            ViewBag.Libro = IdLibro;
            ViewBag.Usuario = IdUser;
            return View();
        }
        [HttpPost]
        public ActionResult Reservar([Bind(Include = "IdReserva,IdUsuario,IdLibro")] reservaLibro reserva, FormCollection form)
        {
            var IdLibroq = form["IdLibro"];
            var conversion = Int32.Parse(IdLibroq);
            var libroDB = reserva.IdLibro;

            var tmm = 2;

            var IdUserq = form["IdUsuario"];
            var UsuarioDB = reserva.IdUsuario;

            

            if (ModelState.IsValid)
            {
                //var usuario = User.Identity.GetUserName(); ;
                //var libro =

                if ((tmm == libroDB) && (IdUserq == UsuarioDB))
                {
                    ViewBag.LibroId1 = conversion;
                    ViewBag.LibroId2 = libroDB;

                    ViewBag.Error = "Lo siento, pero ya ha seleccionado este libro";
                }
                else
                {
                    ViewBag.Error = "Su libro se ha inscrito correctamente";
                    db.reservaActiva.Add(reserva);
                    db.SaveChanges();
                }
                //return RedirectToAction("Index");
            }

            return View(reserva);
        }
    }
}