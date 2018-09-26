using Livraria.DataAccess.Contexts;
using Livraria.DomainModel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Projeto01.Controllers
{
    public class EditorasController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Editoras
        public ActionResult Index()
        {
            return View(db.EditorasSet.ToList());
        }

        // GET: Editoras/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editora editora = db.EditorasSet.Find(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View(editora);
        }

        // GET: Editoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EditoraId,Nome")] Editora editora)
        {
            if (ModelState.IsValid)
            {
                editora.EditoraId = Guid.NewGuid();
                db.EditorasSet.Add(editora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editora);
        }

        // GET: Editoras/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editora editora = db.EditorasSet.Find(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View(editora);
        }

        // POST: Editoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EditoraId,Nome")] Editora editora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editora);
        }

        // GET: Editoras/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editora editora = db.EditorasSet.Find(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View(editora);
        }

        // POST: Editoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Editora editora = db.EditorasSet.Find(id);
            db.EditorasSet.Remove(editora);
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
