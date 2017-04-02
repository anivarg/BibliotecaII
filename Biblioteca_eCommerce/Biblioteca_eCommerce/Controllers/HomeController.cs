using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca_eCommerce.Models;
using System.Data.Entity;

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
            //var IdLibro = form["IdLibro"];
            //var IdUser = form["IdUsuario"];
            //ViewBag.Libro = IdLibro;
            //ViewBag.Usuario = IdUser;
            return View();
        }
        [HttpPost]
        public ActionResult Reservar([Bind(Include = "IdReserva,IdUsuario,IdLibro")] reservaLibro reserva)
        {
            if (ModelState.IsValid)
            {
                db.reservaActiva.Add(reserva);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(reserva);
        }
    }
}