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
    public class acaoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: acao
        public ActionResult Index()
        {
            return View(db.acao.ToList());
        }

        // GET: acao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acao acao = db.acao.Find(id);
            if (acao == null)
            {
                return HttpNotFound();
            }
            return View(acao);
        }

        // GET: acao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: acao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_acao,nome")] acao acao)
        {
            if (ModelState.IsValid)
            {
                db.acao.Add(acao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acao);
        }

        // GET: acao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acao acao = db.acao.Find(id);
            if (acao == null)
            {
                return HttpNotFound();
            }
            return View(acao);
        }

        // POST: acao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_acao,nome")] acao acao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acao);
        }

        // GET: acao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acao acao = db.acao.Find(id);
            if (acao == null)
            {
                return HttpNotFound();
            }
            return View(acao);
        }

        // POST: acao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acao acao = db.acao.Find(id);
            db.acao.Remove(acao);
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
