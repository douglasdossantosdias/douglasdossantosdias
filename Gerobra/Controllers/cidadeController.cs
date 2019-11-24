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
    public class cidadeController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: cidade
        public ActionResult Index()
        {
            var cidade = db.cidade.Include(c => c.uf1);
            return View(cidade.ToList());
        }

        // GET: cidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cidade cidade = db.cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: cidade/Create
        public ActionResult Create()
        {
            ViewBag.id_uf = new SelectList(db.uf, "id_uf", "sigla");
            return View();
        }

        // POST: cidade/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cidade,nome,sin_vara_federal,codigo_ibge,id_orgao,observacao,uf,id_uf")] cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_uf = new SelectList(db.uf, "id_uf", "sigla", cidade.id_uf);
            return View(cidade);
        }

        // GET: cidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cidade cidade = db.cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_uf = new SelectList(db.uf, "id_uf", "sigla", cidade.id_uf);
            return View(cidade);
        }

        // POST: cidade/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cidade,nome,sin_vara_federal,codigo_ibge,id_orgao,observacao,uf,id_uf")] cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_uf = new SelectList(db.uf, "id_uf", "sigla", cidade.id_uf);
            return View(cidade);
        }

        // GET: cidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cidade cidade = db.cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cidade cidade = db.cidade.Find(id);
            db.cidade.Remove(cidade);
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
