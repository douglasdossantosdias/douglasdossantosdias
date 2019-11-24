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
    public class cor_racaController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: cor_raca
        public ActionResult Index()
        {
            return View(db.cor_raca.ToList());
        }

        // GET: cor_raca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cor_raca cor_raca = db.cor_raca.Find(id);
            if (cor_raca == null)
            {
                return HttpNotFound();
            }
            return View(cor_raca);
        }

        // GET: cor_raca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cor_raca/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cor_raca,descricao")] cor_raca cor_raca)
        {
            if (ModelState.IsValid)
            {
                db.cor_raca.Add(cor_raca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cor_raca);
        }

        // GET: cor_raca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cor_raca cor_raca = db.cor_raca.Find(id);
            if (cor_raca == null)
            {
                return HttpNotFound();
            }
            return View(cor_raca);
        }

        // POST: cor_raca/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cor_raca,descricao")] cor_raca cor_raca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cor_raca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cor_raca);
        }

        // GET: cor_raca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cor_raca cor_raca = db.cor_raca.Find(id);
            if (cor_raca == null)
            {
                return HttpNotFound();
            }
            return View(cor_raca);
        }

        // POST: cor_raca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cor_raca cor_raca = db.cor_raca.Find(id);
            db.cor_raca.Remove(cor_raca);
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
