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

        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.autores).Include(l => l.Bibliografia).Include(l => l.Editora);
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
    }
}