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
    public class grau_instrucaoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: grau_instrucao
        public ActionResult Index()
        {
            var grau_instrucao = db.grau_instrucao.Include(g => g.tipo_curso);
            return View(grau_instrucao.ToList());
        }

        // GET: grau_instrucao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grau_instrucao grau_instrucao = db.grau_instrucao.Find(id);
            if (grau_instrucao == null)
            {
                return HttpNotFound();
            }
            return View(grau_instrucao);
        }

        // GET: grau_instrucao/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_curso = new SelectList(db.tipo_curso, "id_tipo_curso", "nome");
            return View();
        }

        // POST: grau_instrucao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_grau_instrucao,descricao,ordem,id_tipo_curso")] grau_instrucao grau_instrucao)
        {
            if (ModelState.IsValid)
            {
                db.grau_instrucao.Add(grau_instrucao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_curso = new SelectList(db.tipo_curso, "id_tipo_curso", "nome", grau_instrucao.id_tipo_curso);
            return View(grau_instrucao);
        }

        // GET: grau_instrucao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grau_instrucao grau_instrucao = db.grau_instrucao.Find(id);
            if (grau_instrucao == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_curso = new SelectList(db.tipo_curso, "id_tipo_curso", "nome", grau_instrucao.id_tipo_curso);
            return View(grau_instrucao);
        }

        // POST: grau_instrucao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_grau_instrucao,descricao,ordem,id_tipo_curso")] grau_instrucao grau_instrucao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grau_instrucao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_curso = new SelectList(db.tipo_curso, "id_tipo_curso", "nome", grau_instrucao.id_tipo_curso);
            return View(grau_instrucao);
        }

        // GET: grau_instrucao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grau_instrucao grau_instrucao = db.grau_instrucao.Find(id);
            if (grau_instrucao == null)
            {
                return HttpNotFound();
            }
            return View(grau_instrucao);
        }

        // POST: grau_instrucao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grau_instrucao grau_instrucao = db.grau_instrucao.Find(id);
            db.grau_instrucao.Remove(grau_instrucao);
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
