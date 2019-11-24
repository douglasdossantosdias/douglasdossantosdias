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
    public class tipo_sanguineoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_sanguineo
        public ActionResult Index()
        {
            return View(db.tipo_sanguineo.ToList());
        }

        // GET: tipo_sanguineo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_sanguineo tipo_sanguineo = db.tipo_sanguineo.Find(id);
            if (tipo_sanguineo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_sanguineo);
        }

        // GET: tipo_sanguineo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_sanguineo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_sanguineo,descricao")] tipo_sanguineo tipo_sanguineo)
        {
            if (ModelState.IsValid)
            {
                db.tipo_sanguineo.Add(tipo_sanguineo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_sanguineo);
        }

        // GET: tipo_sanguineo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_sanguineo tipo_sanguineo = db.tipo_sanguineo.Find(id);
            if (tipo_sanguineo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_sanguineo);
        }

        // POST: tipo_sanguineo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_sanguineo,descricao")] tipo_sanguineo tipo_sanguineo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_sanguineo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_sanguineo);
        }

        // GET: tipo_sanguineo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_sanguineo tipo_sanguineo = db.tipo_sanguineo.Find(id);
            if (tipo_sanguineo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_sanguineo);
        }

        // POST: tipo_sanguineo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_sanguineo tipo_sanguineo = db.tipo_sanguineo.Find(id);
            db.tipo_sanguineo.Remove(tipo_sanguineo);
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
