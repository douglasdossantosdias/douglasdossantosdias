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
    public class tab_backupController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tab_backup
        public ActionResult Index()
        {
            var tab_backup = db.tab_backup.Include(t => t.tipo_backup).Include(t => t.usuario);
            return View(tab_backup.ToList());
        }

        // GET: tab_backup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tab_backup tab_backup = db.tab_backup.Find(id);
            if (tab_backup == null)
            {
                return HttpNotFound();
            }
            return View(tab_backup);
        }

        // GET: tab_backup/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_backup = new SelectList(db.tipo_backup, "id_tipo_backup", "nome");
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario");
            return View();
        }

        // POST: tab_backup/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tab_backup,nome_arquivo,dta_backup,id_usuario,sin_ativo,id_tipo_backup")] tab_backup tab_backup)
        {
            if (ModelState.IsValid)
            {
                db.tab_backup.Add(tab_backup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_backup = new SelectList(db.tipo_backup, "id_tipo_backup", "nome", tab_backup.id_tipo_backup);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", tab_backup.id_usuario);
            return View(tab_backup);
        }

        // GET: tab_backup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tab_backup tab_backup = db.tab_backup.Find(id);
            if (tab_backup == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_backup = new SelectList(db.tipo_backup, "id_tipo_backup", "nome", tab_backup.id_tipo_backup);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", tab_backup.id_usuario);
            return View(tab_backup);
        }

        // POST: tab_backup/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tab_backup,nome_arquivo,dta_backup,id_usuario,sin_ativo,id_tipo_backup")] tab_backup tab_backup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_backup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_backup = new SelectList(db.tipo_backup, "id_tipo_backup", "nome", tab_backup.id_tipo_backup);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", tab_backup.id_usuario);
            return View(tab_backup);
        }

        // GET: tab_backup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tab_backup tab_backup = db.tab_backup.Find(id);
            if (tab_backup == null)
            {
                return HttpNotFound();
            }
            return View(tab_backup);
        }

        // POST: tab_backup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tab_backup tab_backup = db.tab_backup.Find(id);
            db.tab_backup.Remove(tab_backup);
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
