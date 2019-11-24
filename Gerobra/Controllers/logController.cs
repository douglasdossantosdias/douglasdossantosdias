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
    public class logController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: log
        public ActionResult Index()
        {
            var log = db.log.Include(l => l.acao).Include(l => l.usuario);
            return View(log.ToList());
        }

        // GET: log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.log.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // GET: log/Create
        public ActionResult Create()
        {
            ViewBag.id_acao = new SelectList(db.acao, "id_acao", "nome");
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario");
            return View();
        }

        // POST: log/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_log,dta_log,banco_dados,entidade,id_entidade,id_usuario,id_acao")] log log)
        {
            if (ModelState.IsValid)
            {
                db.log.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_acao = new SelectList(db.acao, "id_acao", "nome", log.id_acao);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", log.id_usuario);
            return View(log);
        }

        // GET: log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.log.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_acao = new SelectList(db.acao, "id_acao", "nome", log.id_acao);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", log.id_usuario);
            return View(log);
        }

        // POST: log/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_log,dta_log,banco_dados,entidade,id_entidade,id_usuario,id_acao")] log log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_acao = new SelectList(db.acao, "id_acao", "nome", log.id_acao);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", log.id_usuario);
            return View(log);
        }

        // GET: log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            log log = db.log.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            log log = db.log.Find(id);
            db.log.Remove(log);
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
