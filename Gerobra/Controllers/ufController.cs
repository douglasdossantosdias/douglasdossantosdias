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
    public class ufController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: uf
        public ActionResult Index()
        {
            var uf = db.uf.Include(u => u.pais);
            return View(uf.ToList());
        }

        // GET: uf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uf uf = db.uf.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // GET: uf/Create
        public ActionResult Create()
        {
            ViewBag.id_pais = new SelectList(db.pais, "id_pais", "nome");
            return View();
        }

        // POST: uf/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_uf,sigla,nome,id_pais")] uf uf)
        {
            if (ModelState.IsValid)
            {
                db.uf.Add(uf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pais = new SelectList(db.pais, "id_pais", "nome", uf.id_pais);
            return View(uf);
        }

        // GET: uf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uf uf = db.uf.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pais = new SelectList(db.pais, "id_pais", "nome", uf.id_pais);
            return View(uf);
        }

        // POST: uf/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_uf,sigla,nome,id_pais")] uf uf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.pais, "id_pais", "nome", uf.id_pais);
            return View(uf);
        }

        // GET: uf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uf uf = db.uf.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // POST: uf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uf uf = db.uf.Find(id);
            db.uf.Remove(uf);
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
