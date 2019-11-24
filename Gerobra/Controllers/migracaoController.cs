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
    public class migracaoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: migracao
        public ActionResult Index()
        {
            var migracao = db.migracao.Include(m => m.funcionario).Include(m => m.usuario);
            return View(migracao.ToList());
        }

        // GET: migracao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            migracao migracao = db.migracao.Find(id);
            if (migracao == null)
            {
                return HttpNotFound();
            }
            return View(migracao);
        }

        // GET: migracao/Create
        public ActionResult Create()
        {
            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario");
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario");
            return View();
        }

        // POST: migracao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_migracao,dta_migracao,entidade_origem,entidade_destino,id_funcionario,sin_ativo,id_usuario")] migracao migracao)
        {
            if (ModelState.IsValid)
            {
                db.migracao.Add(migracao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario", migracao.id_funcionario);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", migracao.id_usuario);
            return View(migracao);
        }

        // GET: migracao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            migracao migracao = db.migracao.Find(id);
            if (migracao == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario", migracao.id_funcionario);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", migracao.id_usuario);
            return View(migracao);
        }

        // POST: migracao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_migracao,dta_migracao,entidade_origem,entidade_destino,id_funcionario,sin_ativo,id_usuario")] migracao migracao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(migracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario", migracao.id_funcionario);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", migracao.id_usuario);
            return View(migracao);
        }

        // GET: migracao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            migracao migracao = db.migracao.Find(id);
            if (migracao == null)
            {
                return HttpNotFound();
            }
            return View(migracao);
        }

        // POST: migracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            migracao migracao = db.migracao.Find(id);
            db.migracao.Remove(migracao);
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
