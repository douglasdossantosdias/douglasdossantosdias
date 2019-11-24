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
    public class nacionalidadeController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: nacionalidade
        public ActionResult Index()
        {
            return View(db.nacionalidade.ToList());
        }

        // GET: nacionalidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nacionalidade nacionalidade = db.nacionalidade.Find(id);
            if (nacionalidade == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidade);
        }

        // GET: nacionalidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nacionalidade/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_nacionalidade,descricao")] nacionalidade nacionalidade)
        {
            if (ModelState.IsValid)
            {
                db.nacionalidade.Add(nacionalidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nacionalidade);
        }

        // GET: nacionalidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nacionalidade nacionalidade = db.nacionalidade.Find(id);
            if (nacionalidade == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidade);
        }

        // POST: nacionalidade/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_nacionalidade,descricao")] nacionalidade nacionalidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nacionalidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nacionalidade);
        }

        // GET: nacionalidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nacionalidade nacionalidade = db.nacionalidade.Find(id);
            if (nacionalidade == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidade);
        }

        // POST: nacionalidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nacionalidade nacionalidade = db.nacionalidade.Find(id);
            db.nacionalidade.Remove(nacionalidade);
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
