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
    public class estado_civilController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: estado_civil
        public ActionResult Index()
        {
            return View(db.estado_civil.ToList());
        }

        // GET: estado_civil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_civil estado_civil = db.estado_civil.Find(id);
            if (estado_civil == null)
            {
                return HttpNotFound();
            }
            return View(estado_civil);
        }

        // GET: estado_civil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estado_civil/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado_civil,descricao")] estado_civil estado_civil)
        {
            if (ModelState.IsValid)
            {
                db.estado_civil.Add(estado_civil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_civil);
        }

        // GET: estado_civil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_civil estado_civil = db.estado_civil.Find(id);
            if (estado_civil == null)
            {
                return HttpNotFound();
            }
            return View(estado_civil);
        }

        // POST: estado_civil/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado_civil,descricao")] estado_civil estado_civil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_civil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_civil);
        }

        // GET: estado_civil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_civil estado_civil = db.estado_civil.Find(id);
            if (estado_civil == null)
            {
                return HttpNotFound();
            }
            return View(estado_civil);
        }

        // POST: estado_civil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estado_civil estado_civil = db.estado_civil.Find(id);
            db.estado_civil.Remove(estado_civil);
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
