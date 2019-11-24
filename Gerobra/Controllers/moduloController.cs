using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gerobra.Models;

namespace Gerobra.Controllers
{
    public class moduloController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: modulo
        public ActionResult Index()
        {
            return View(db.modulo.ToList());
        }

        // GET: modulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modulo modulo = db.modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // GET: modulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: modulo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_modulo,nome,sin_ativo")] modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.modulo.Add(modulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modulo);
        }

        // GET: modulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modulo modulo = db.modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // POST: modulo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_modulo,nome,sin_ativo")] modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modulo);
        }

        // GET: modulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modulo modulo = db.modulo.Find(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // POST: modulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modulo modulo = db.modulo.Find(id);
            db.modulo.Remove(modulo);
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
