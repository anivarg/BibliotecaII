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
    public class PrestamoesController : Controller
    {
        private BibliotecaDbContext db = new BibliotecaDbContext();

        // GET: Prestamoes
        public ActionResult Index()
        {
            var prestm = db.Prestamos.Include(l => l.Usuario).Include(l => l.Empleado).Include(l => l.Libro);
            return View(prestm.ToList());
        }

        // GET: Prestamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.IdLibro = new SelectList(db.Libros, "IdLibro", "Nombre");
            ViewBag.IdUsuarios = new SelectList(db.Usuarios, "IdUsuarios", "Nombre");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPrestamo,IdEmpleado,IdLibro,IdUsuarios,FechaPrest,FechaDevol,MontoxDia,cantDias,Comentario,estado")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamos.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.IdLibro = new SelectList(db.Libros, "IdLibro", "Nombre");
            ViewBag.IdUsuarios = new SelectList(db.Usuarios, "IdUsuarios", "Nombre");
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.IdLibro = new SelectList(db.Libros, "IdLibro", "Nombre");
            ViewBag.IdUsuarios = new SelectList(db.Usuarios, "IdUsuarios", "Nombre");
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPrestamo,IdEmpleado,IdLibro,IdUsuarios,FechaPrest,FechaDevol,MontoxDia,cantDias,Comentario,estado")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.IdLibro = new SelectList(db.Libros, "IdLibro", "Nombre");
            ViewBag.IdUsuarios = new SelectList(db.Usuarios, "IdUsuarios", "Nombre");
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            db.Prestamos.Remove(prestamo);
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
