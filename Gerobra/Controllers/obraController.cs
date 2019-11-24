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
    public class obraController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: obra
        public ActionResult Index()
        {
            var obra = db.obra.Include(o => o.endereco).Include(o => o.status_obra).Include(o => o.tipo_obra);
            return View(obra.ToList());
        }

        // GET: obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            obra obra = db.obra.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        // GET: obra/Create
        public ActionResult Create()
        {
            ViewBag.id_endereco = new SelectList(db.endereco, "id_endereco", "logradouro");
            ViewBag.id_status_obra = new SelectList(db.status_obra, "id_status_obra", "descricao");
            ViewBag.id_tipo_obra = new SelectList(db.tipo_obra, "id_tipo_obra", "descricao");
            return View();
        }

        // POST: obra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_obra,cod_obra,descricao,dta_inicio,dta_fim,dta_previsao_inicio,dta_previsao_fim,orcamento_previsao,orcamento_total,id_endereco,id_status_obra,id_tipo_obra,sin_ativo,C_default_")] obra obra)
        {
            if (ModelState.IsValid)
            {
                db.obra.Add(obra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_endereco = new SelectList(db.endereco, "id_endereco", "logradouro", obra.id_endereco);
            ViewBag.id_status_obra = new SelectList(db.status_obra, "id_status_obra", "descricao", obra.id_status_obra);
            ViewBag.id_tipo_obra = new SelectList(db.tipo_obra, "id_tipo_obra", "descricao", obra.id_tipo_obra);
            return View(obra);
        }

        // GET: obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            obra obra = db.obra.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_endereco = new SelectList(db.endereco, "id_endereco", "logradouro", obra.id_endereco);
            ViewBag.id_status_obra = new SelectList(db.status_obra, "id_status_obra", "descricao", obra.id_status_obra);
            ViewBag.id_tipo_obra = new SelectList(db.tipo_obra, "id_tipo_obra", "descricao", obra.id_tipo_obra);
            return View(obra);
        }

        // POST: obra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_obra,cod_obra,descricao,dta_inicio,dta_fim,dta_previsao_inicio,dta_previsao_fim,orcamento_previsao,orcamento_total,id_endereco,id_status_obra,id_tipo_obra,sin_ativo,C_default_")] obra obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_endereco = new SelectList(db.endereco, "id_endereco", "logradouro", obra.id_endereco);
            ViewBag.id_status_obra = new SelectList(db.status_obra, "id_status_obra", "descricao", obra.id_status_obra);
            ViewBag.id_tipo_obra = new SelectList(db.tipo_obra, "id_tipo_obra", "descricao", obra.id_tipo_obra);
            return View(obra);
        }

        // GET: obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            obra obra = db.obra.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        // POST: obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            obra obra = db.obra.Find(id);
            db.obra.Remove(obra);
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
