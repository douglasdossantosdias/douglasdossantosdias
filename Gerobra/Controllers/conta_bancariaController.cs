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
    public class conta_bancariaController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: conta_bancaria
        public ActionResult Index()
        {
            var conta_bancaria = db.conta_bancaria.Include(c => c.banco).Include(c => c.pessoa);
            return View(conta_bancaria.ToList());
        }

        // GET: conta_bancaria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conta_bancaria conta_bancaria = db.conta_bancaria.Find(id);
            if (conta_bancaria == null)
            {
                return HttpNotFound();
            }
            return View(conta_bancaria);
        }

        // GET: conta_bancaria/Create
        public ActionResult Create()
        {
            ViewBag.id_banco = new SelectList(db.banco, "id_banco", "numero");
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome");
            return View();
        }

        // POST: conta_bancaria/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_conta_bancaria,agencia,conta,id_banco,id_pessoa")] conta_bancaria conta_bancaria)
        {
            if (ModelState.IsValid)
            {
                db.conta_bancaria.Add(conta_bancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_banco = new SelectList(db.banco, "id_banco", "numero", conta_bancaria.id_banco);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", conta_bancaria.id_pessoa);
            return View(conta_bancaria);
        }

        // GET: conta_bancaria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conta_bancaria conta_bancaria = db.conta_bancaria.Find(id);
            if (conta_bancaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_banco = new SelectList(db.banco, "id_banco", "numero", conta_bancaria.id_banco);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", conta_bancaria.id_pessoa);
            return View(conta_bancaria);
        }

        // POST: conta_bancaria/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_conta_bancaria,agencia,conta,id_banco,id_pessoa")] conta_bancaria conta_bancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conta_bancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_banco = new SelectList(db.banco, "id_banco", "numero", conta_bancaria.id_banco);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", conta_bancaria.id_pessoa);
            return View(conta_bancaria);
        }

        // GET: conta_bancaria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conta_bancaria conta_bancaria = db.conta_bancaria.Find(id);
            if (conta_bancaria == null)
            {
                return HttpNotFound();
            }
            return View(conta_bancaria);
        }

        // POST: conta_bancaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            conta_bancaria conta_bancaria = db.conta_bancaria.Find(id);
            db.conta_bancaria.Remove(conta_bancaria);
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
