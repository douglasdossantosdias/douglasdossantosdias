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
    public class status_obraController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: status_obra
        public ActionResult Index()
        {
            return View(db.status_obra.ToList());
        }

        // GET: status_obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            status_obra status_obra = db.status_obra.Find(id);
            if (status_obra == null)
            {
                return HttpNotFound();
            }
            return View(status_obra);
        }

        // GET: status_obra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: status_obra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_status_obra,descricao,sin_ativo")] status_obra status_obra)
        {
            if (ModelState.IsValid)
            {
                db.status_obra.Add(status_obra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(status_obra);
        }

        // GET: status_obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            status_obra status_obra = db.status_obra.Find(id);
            if (status_obra == null)
            {
                return HttpNotFound();
            }
            return View(status_obra);
        }

        // POST: status_obra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_status_obra,descricao,sin_ativo")] status_obra status_obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status_obra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status_obra);
        }

        // GET: status_obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            status_obra status_obra = db.status_obra.Find(id);
            if (status_obra == null)
            {
                return HttpNotFound();
            }
            return View(status_obra);
        }

        // POST: status_obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            status_obra status_obra = db.status_obra.Find(id);
            db.status_obra.Remove(status_obra);
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
