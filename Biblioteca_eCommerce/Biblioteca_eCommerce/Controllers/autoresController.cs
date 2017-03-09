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
    public class autoresController : Controller
    {
        private BibliotecaDbContext db = new BibliotecaDbContext();

        // GET: autores
        public ActionResult Index()
        {
            return View(db.autor.ToList());
        }

        // GET: autores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autores autores = db.autor.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // GET: autores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: autores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAutor,Nombre,Pais,Idioma,Estado")] autores autores)
        {
            if (ModelState.IsValid)
            {
                db.autor.Add(autores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autores);
        }

        // GET: autores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autores autores = db.autor.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // POST: autores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAutor,Nombre,Pais,Idioma,Estado")] autores autores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autores);
        }

        // GET: autores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autores autores = db.autor.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }

        // POST: autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            autores autores = db.autor.Find(id);
            db.autor.Remove(autores);
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
