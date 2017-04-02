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
    public class reservaLibroesController : Controller
    {
        private BibliotecaDbContext db = new BibliotecaDbContext();

        

        // GET: reservaLibroes
        public ActionResult Index(string Criterio = null)
        {
           // var TryF = "0";
            var filtro = db.reservaActiva.Where(p => Criterio == null || p.IdUsuario.StartsWith(Criterio));
            return View(filtro.ToList());
        }

        // GET: reservaLibroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservaLibro reservaLibro = db.reservaActiva.Find(id);
            if (reservaLibro == null)
            {
                return HttpNotFound();
            }
            return View(reservaLibro);
        }

        // GET: reservaLibroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reservaLibroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,IdUsuario,IdLibro")] reservaLibro reservaLibro)
        {
            if (ModelState.IsValid)
            {
                db.reservaActiva.Add(reservaLibro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservaLibro);
        }

        // GET: reservaLibroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservaLibro reservaLibro = db.reservaActiva.Find(id);
            if (reservaLibro == null)
            {
                return HttpNotFound();
            }
            return View(reservaLibro);
        }

        // POST: reservaLibroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReserva,IdUsuario,IdLibro")] reservaLibro reservaLibro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservaLibro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservaLibro);
        }

        // GET: reservaLibroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservaLibro reservaLibro = db.reservaActiva.Find(id);
            if (reservaLibro == null)
            {
                return HttpNotFound();
            }
            return View(reservaLibro);
        }

        // POST: reservaLibroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservaLibro reservaLibro = db.reservaActiva.Find(id);
            db.reservaActiva.Remove(reservaLibro);
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
