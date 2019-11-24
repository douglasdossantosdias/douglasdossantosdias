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
    public class enderecoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: endereco
        public ActionResult Index()
        {
            var endereco = db.endereco.Include(e => e.cidade).Include(e => e.pessoa);
            return View(endereco.ToList());
        }

        // GET: endereco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: endereco/Create
        public ActionResult Create()
        {
            ViewBag.id_cidade = new SelectList(db.cidade, "id_cidade", "nome");
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome");
            return View();
        }

        // POST: endereco/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_endereco,logradouro,complemento,numero,bairro,id_cidade,id_pessoa,cep")] endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.endereco.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cidade = new SelectList(db.cidade, "id_cidade", "nome", endereco.id_cidade);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", endereco.id_pessoa);
            return View(endereco);
        }

        // GET: endereco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cidade = new SelectList(db.cidade, "id_cidade", "nome", endereco.id_cidade);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", endereco.id_pessoa);
            return View(endereco);
        }

        // POST: endereco/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_endereco,logradouro,complemento,numero,bairro,id_cidade,id_pessoa,cep")] endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cidade = new SelectList(db.cidade, "id_cidade", "nome", endereco.id_cidade);
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", endereco.id_pessoa);
            return View(endereco);
        }

        // GET: endereco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            endereco endereco = db.endereco.Find(id);
            db.endereco.Remove(endereco);
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
