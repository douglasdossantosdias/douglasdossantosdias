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
    public class tipo_obraController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_obra
        public ActionResult Index()
        {
            return View(db.tipo_obra.ToList());
        }

        // GET: tipo_obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_obra tipo_obra = db.tipo_obra.Find(id);
            if (tipo_obra == null)
            {
                return HttpNotFound();
            }
            return View(tipo_obra);
        }

        // GET: tipo_obra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_obra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_obra,descricao")] tipo_obra tipo_obra)
        {
            if (ModelState.IsValid)
            {
                db.tipo_obra.Add(tipo_obra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_obra);
        }

        // GET: tipo_obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_obra tipo_obra = db.tipo_obra.Find(id);
            if (tipo_obra == null)
            {
                return HttpNotFound();
            }
            return View(tipo_obra);
        }

        // POST: tipo_obra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_obra,descricao")] tipo_obra tipo_obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_obra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_obra);
        }

        // GET: tipo_obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_obra tipo_obra = db.tipo_obra.Find(id);
            if (tipo_obra == null)
            {
                return HttpNotFound();
            }
            return View(tipo_obra);
        }

        // POST: tipo_obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_obra tipo_obra = db.tipo_obra.Find(id);
            db.tipo_obra.Remove(tipo_obra);
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
