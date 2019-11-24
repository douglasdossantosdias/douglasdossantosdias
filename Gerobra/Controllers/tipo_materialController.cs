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
    public class tipo_materialController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_material
        public ActionResult Index()
        {
            return View(db.tipo_material.ToList());
        }

        // GET: tipo_material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_material tipo_material = db.tipo_material.Find(id);
            if (tipo_material == null)
            {
                return HttpNotFound();
            }
            return View(tipo_material);
        }

        // GET: tipo_material/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_material/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_material,nome")] tipo_material tipo_material)
        {
            if (ModelState.IsValid)
            {
                db.tipo_material.Add(tipo_material);
                db.SaveChanges();
                return RedirectToAction("Create", "material");
            }

            return View(tipo_material);
        }

        // GET: tipo_material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_material tipo_material = db.tipo_material.Find(id);
            if (tipo_material == null)
            {
                return HttpNotFound();
            }
            return View(tipo_material);
        }

        // POST: tipo_material/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_material,nome")] tipo_material tipo_material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_material);
        }

        // GET: tipo_material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_material tipo_material = db.tipo_material.Find(id);
            if (tipo_material == null)
            {
                return HttpNotFound();
            }
            return View(tipo_material);
        }

        // POST: tipo_material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_material tipo_material = db.tipo_material.Find(id);
            db.tipo_material.Remove(tipo_material);
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
