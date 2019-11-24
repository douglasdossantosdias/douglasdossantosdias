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
    public class telefoneController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: telefone
        public ActionResult Index(string searchString)
        {
            var telefone = db.telefone.Include(t => t.obra).Include(t => t.pessoa);

            if (!String.IsNullOrEmpty(searchString))
            {
                var tel = telefone.Where(name => name.pessoa.nome.ToUpper().Contains(searchString.ToUpper()));
                return View(tel.ToList());

            }

            return View(telefone.ToList());
        }

        // GET: telefone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefone telefone = db.telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // GET: telefone/Create
        public ActionResult Create()
        {
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra");
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome");
            return View();
        }

        // POST: telefone/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_telefone,sta_tipo,numero,ramal,id_pessoa,id_obra")] telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.telefone.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", telefone.id_obra);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", telefone.id_pessoa);
            return View(telefone);
        }

        // GET: telefone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefone telefone = db.telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", telefone.id_obra);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", telefone.id_pessoa);
            return View(telefone);
        }

        // POST: telefone/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_telefone,sta_tipo,numero,ramal,id_pessoa,id_obra")] telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", telefone.id_obra);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", telefone.id_pessoa);
            return View(telefone);
        }

        // GET: telefone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefone telefone = db.telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: telefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            telefone telefone = db.telefone.Find(id);
            db.telefone.Remove(telefone);
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
