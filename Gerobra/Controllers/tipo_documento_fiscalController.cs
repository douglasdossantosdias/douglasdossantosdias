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
    public class tipo_documento_fiscalController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_documento_fiscal
        public ActionResult Index()
        {
            return View(db.tipo_documento_fiscal.ToList());
        }

        // GET: tipo_documento_fiscal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_documento_fiscal tipo_documento_fiscal = db.tipo_documento_fiscal.Find(id);
            if (tipo_documento_fiscal == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento_fiscal);
        }

        // GET: tipo_documento_fiscal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_documento_fiscal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_documento_fiscal,nome")] tipo_documento_fiscal tipo_documento_fiscal)
        {
            if (ModelState.IsValid)
            {
                db.tipo_documento_fiscal.Add(tipo_documento_fiscal);
                db.SaveChanges();
                return RedirectToAction("Create","documento_fiscal");
            }

            return View(tipo_documento_fiscal);
        }

        // GET: tipo_documento_fiscal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_documento_fiscal tipo_documento_fiscal = db.tipo_documento_fiscal.Find(id);
            if (tipo_documento_fiscal == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento_fiscal);
        }

        // POST: tipo_documento_fiscal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_documento_fiscal,nome")] tipo_documento_fiscal tipo_documento_fiscal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_documento_fiscal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_documento_fiscal);
        }

        // GET: tipo_documento_fiscal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_documento_fiscal tipo_documento_fiscal = db.tipo_documento_fiscal.Find(id);
            if (tipo_documento_fiscal == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento_fiscal);
        }

        // POST: tipo_documento_fiscal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_documento_fiscal tipo_documento_fiscal = db.tipo_documento_fiscal.Find(id);
            db.tipo_documento_fiscal.Remove(tipo_documento_fiscal);
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
