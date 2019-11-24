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
    public class bancoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: banco
        public ActionResult Index()
        {
            return View(db.banco.ToList());
        }

        // GET: banco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banco banco = db.banco.Find(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            return View(banco);
        }

        // GET: banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: banco/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_banco,numero,nome")] banco banco)
        {
            if (ModelState.IsValid)
            {
                db.banco.Add(banco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banco);
        }

        // GET: banco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banco banco = db.banco.Find(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            return View(banco);
        }

        // POST: banco/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_banco,numero,nome")] banco banco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banco);
        }

        // GET: banco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banco banco = db.banco.Find(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            return View(banco);
        }

        // POST: banco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            banco banco = db.banco.Find(id);
            db.banco.Remove(banco);
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
