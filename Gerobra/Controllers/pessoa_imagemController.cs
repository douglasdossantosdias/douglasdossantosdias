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
    public class pessoa_imagemController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: pessoa_imagem
        public ActionResult Index()
        {
            var pessoa_imagem = db.pessoa_imagem.Include(p => p.pessoa);
            return View(pessoa_imagem.ToList());
        }

        // GET: pessoa_imagem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa_imagem pessoa_imagem = db.pessoa_imagem.Find(id);
            if (pessoa_imagem == null)
            {
                return HttpNotFound();
            }
            return View(pessoa_imagem);
        }

        // GET: pessoa_imagem/Create
        public ActionResult Create()
        {
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome");
            return View();
        }

        // POST: pessoa_imagem/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pessoa,foto,extensao_foto")] pessoa_imagem pessoa_imagem)
        {
            if (ModelState.IsValid)
            {
                db.pessoa_imagem.Add(pessoa_imagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", pessoa_imagem.id_pessoa);
            return View(pessoa_imagem);
        }

        // GET: pessoa_imagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa_imagem pessoa_imagem = db.pessoa_imagem.Find(id);
            if (pessoa_imagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", pessoa_imagem.id_pessoa);
            return View(pessoa_imagem);
        }

        // POST: pessoa_imagem/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pessoa,foto,extensao_foto")] pessoa_imagem pessoa_imagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa_imagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", pessoa_imagem.id_pessoa);
            return View(pessoa_imagem);
        }

        // GET: pessoa_imagem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa_imagem pessoa_imagem = db.pessoa_imagem.Find(id);
            if (pessoa_imagem == null)
            {
                return HttpNotFound();
            }
            return View(pessoa_imagem);
        }

        // POST: pessoa_imagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pessoa_imagem pessoa_imagem = db.pessoa_imagem.Find(id);
            db.pessoa_imagem.Remove(pessoa_imagem);
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
