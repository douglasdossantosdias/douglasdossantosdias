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
    public class tipo_backupController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_backup
        public ActionResult Index()
        {
            return View(db.tipo_backup.ToList());
        }

        // GET: tipo_backup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_backup tipo_backup = db.tipo_backup.Find(id);
            if (tipo_backup == null)
            {
                return HttpNotFound();
            }
            return View(tipo_backup);
        }

        // GET: tipo_backup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_backup/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_backup,nome")] tipo_backup tipo_backup)
        {
            if (ModelState.IsValid)
            {
                db.tipo_backup.Add(tipo_backup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_backup);
        }

        // GET: tipo_backup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_backup tipo_backup = db.tipo_backup.Find(id);
            if (tipo_backup == null)
            {
                return HttpNotFound();
            }
            return View(tipo_backup);
        }

        // POST: tipo_backup/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_backup,nome")] tipo_backup tipo_backup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_backup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_backup);
        }

        // GET: tipo_backup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_backup tipo_backup = db.tipo_backup.Find(id);
            if (tipo_backup == null)
            {
                return HttpNotFound();
            }
            return View(tipo_backup);
        }

        // POST: tipo_backup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_backup tipo_backup = db.tipo_backup.Find(id);
            db.tipo_backup.Remove(tipo_backup);
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
