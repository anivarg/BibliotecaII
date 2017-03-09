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
    public class BibliografiasController : Controller
    {
        private BibliotecaDbContext db = new BibliotecaDbContext();

        // GET: Bibliografias
        public ActionResult Index()
        {
            return View(db.Bibliografias.ToList());
        }

        // GET: Bibliografias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliografia bibliografia = db.Bibliografias.Find(id);
            if (bibliografia == null)
            {
                return HttpNotFound();
            }
            return View(bibliografia);
        }

        // GET: Bibliografias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bibliografias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBibliografia,Descripcion,Estado")] Bibliografia bibliografia)
        {
            if (ModelState.IsValid)
            {
                db.Bibliografias.Add(bibliografia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bibliografia);
        }

        // GET: Bibliografias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliografia bibliografia = db.Bibliografias.Find(id);
            if (bibliografia == null)
            {
                return HttpNotFound();
            }
            return View(bibliografia);
        }

        // POST: Bibliografias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBibliografia,Descripcion,Estado")] Bibliografia bibliografia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bibliografia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bibliografia);
        }

        // GET: Bibliografias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliografia bibliografia = db.Bibliografias.Find(id);
            if (bibliografia == null)
            {
                return HttpNotFound();
            }
            return View(bibliografia);
        }

        // POST: Bibliografias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bibliografia bibliografia = db.Bibliografias.Find(id);
            db.Bibliografias.Remove(bibliografia);
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
