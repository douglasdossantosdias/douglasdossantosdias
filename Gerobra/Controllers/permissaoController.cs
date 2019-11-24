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
    public class permissaoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: permissao
        public ActionResult Index()
        {
            var permissao = db.permissao.Include(p => p.grupo).Include(p => p.modulo);
            return View(permissao.ToList());
        }

        // GET: permissao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permissao permissao = db.permissao.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            return View(permissao);
        }

        // GET: permissao/Create
        public ActionResult Create()
        {
            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome");
            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome");
            return View();
        }

        // POST: permissao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_permissao,listar,editar,criar,excluir,visualizar,id_modulo,id_grupo")] permissao permissao)
        {
            if (ModelState.IsValid)
            {
                db.permissao.Add(permissao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome", permissao.id_grupo);
            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome", permissao.id_modulo);
            return View(permissao);
        }

        // GET: permissao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permissao permissao = db.permissao.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome", permissao.id_grupo);
            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome", permissao.id_modulo);
            return View(permissao);
        }

        // POST: permissao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_permissao,listar,editar,criar,excluir,visualizar,id_modulo,id_grupo")] permissao permissao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome", permissao.id_grupo);
            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome", permissao.id_modulo);
            return View(permissao);
        }

        // GET: permissao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permissao permissao = db.permissao.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            return View(permissao);
        }

        // POST: permissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            permissao permissao = db.permissao.Find(id);
            db.permissao.Remove(permissao);
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
