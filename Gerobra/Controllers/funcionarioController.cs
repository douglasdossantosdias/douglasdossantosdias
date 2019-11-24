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
    public class funcionarioController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: funcionario
        public ActionResult Index(string searchString)
        {
            var funcionario = db.funcionario.Include(f => f.pessoa).Include(f => f.tipo_funcionario);

            if (!String.IsNullOrEmpty(searchString))
            {
                var func = funcionario.Where(name => name.pessoa.nome.ToUpper().Contains(searchString.ToUpper()));
                return View(func.ToList());

            }



            return View(funcionario.ToList());




        }

        // GET: funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: funcionario/Create
        public ActionResult Create()
        {
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome");
            ViewBag.id_tipo_funcionario = new SelectList(db.tipo_funcionario, "id_tipo_funcionario", "nome");
            return View();
        }

        // POST: funcionario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_funcionario,id_tipo_funcionario,id_pessoa,sin_ativo")] funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", funcionario.id_pessoa);
            ViewBag.id_tipo_funcionario = new SelectList(db.tipo_funcionario, "id_tipo_funcionario", "nome", funcionario.id_tipo_funcionario);
            return View(funcionario);
        }

        // GET: funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", funcionario.id_pessoa);
            ViewBag.id_tipo_funcionario = new SelectList(db.tipo_funcionario, "id_tipo_funcionario", "nome", funcionario.id_tipo_funcionario);
            return View(funcionario);
        }

        // POST: funcionario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_funcionario,id_tipo_funcionario,id_pessoa,sin_ativo")] funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", funcionario.id_pessoa);
            ViewBag.id_tipo_funcionario = new SelectList(db.tipo_funcionario, "id_tipo_funcionario", "nome", funcionario.id_tipo_funcionario);
            return View(funcionario);
        }

        // GET: funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            funcionario funcionario = db.funcionario.Find(id);
            db.funcionario.Remove(funcionario);
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
