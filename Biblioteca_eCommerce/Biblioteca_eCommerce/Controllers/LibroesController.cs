using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca_eCommerce.Models;

namespace Biblioteca_eCommerce.Controllers
{
    public class LibroesController : Controller
    {
        private BibliotecaDbContext db = new BibliotecaDbContext();

        // GET: Libroes
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.autores).Include(l => l.Bibliografia).Include(l => l.Editora);
            return View(libros.ToList());
        }

        // GET: Libroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libroes/Create
        public ActionResult Create()
        {
            ViewBag.IdAutor = new SelectList(db.autor, "IdAutor", "Nombre");
            ViewBag.IdBibliografia = new SelectList(db.Bibliografias, "IdBibliografia", "Descripcion");
            ViewBag.IdEditoras = new SelectList(db.Editoras, "IdEditoras", "Descripcion");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLibro,Nombre,SignatureTopography,ISBN,IdBibliografia,IdAutor,YearPublish,IdEditoras,Ciencia,IdIdioma,estado")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutor = new SelectList(db.autor, "IdAutor", "Nombre", libro.IdAutor);
            ViewBag.IdBibliografia = new SelectList(db.Bibliografias, "IdBibliografia", "Descripcion", libro.IdBibliografia);
            ViewBag.IdEditoras = new SelectList(db.Editoras, "IdEditoras", "Descripcion", libro.IdEditoras);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAutor = new SelectList(db.autor, "IdAutor", "Nombre", libro.IdAutor);
            ViewBag.IdBibliografia = new SelectList(db.Bibliografias, "IdBibliografia", "Descripcion", libro.IdBibliografia);
            ViewBag.IdEditoras = new SelectList(db.Editoras, "IdEditoras", "Descripcion", libro.IdEditoras);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLibro,Nombre,SignatureTopography,ISBN,IdBibliografia,IdAutor,YearPublish,IdEditoras,Ciencia,IdIdioma,estado")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutor = new SelectList(db.autor, "IdAutor", "Nombre", libro.IdAutor);
            ViewBag.IdBibliografia = new SelectList(db.Bibliografias, "IdBibliografia", "Descripcion", libro.IdBibliografia);
            ViewBag.IdEditoras = new SelectList(db.Editoras, "IdEditoras", "Descripcion", libro.IdEditoras);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libros.Find(id);
            db.Libros.Remove(libro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
