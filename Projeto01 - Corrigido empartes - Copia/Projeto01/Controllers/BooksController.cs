using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Livraria.DataAccess.Contexts;
using Livraria.DomainModel.Models.Entity;


namespace Projeto01.Controllers
{
    public class BooksController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Books
        public ActionResult Index()
        {
            var booksSet = db.BooksSet.Include(b => b.Categoria).Include(b => b.Editora);
            return View(booksSet.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.BooksSet.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaCategoriaId = new SelectList(db.CategoriasSet, "CategoriaId", "Nome");
            ViewBag.EditoraEditoraId = new SelectList(db.EditorasSet, "EditoraId", "Nome");	
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Titulo,Isbn,DataPublicacao,CategoriaCategoriaId,EditoraEditoraId")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.BookId = Guid.NewGuid();
                db.BooksSet.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaCategoriaId = new SelectList(db.CategoriasSet, "CategoriaId", "Nome", book.CategoriaCategoriaId);
            ViewBag.EditoraEditoraId = new SelectList(db.EditorasSet, "EditoraId", "Nome", book.EditoraEditoraId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.BooksSet.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaCategoriaId = new SelectList(db.CategoriasSet, "CategoriaId", "Nome", book.CategoriaCategoriaId);
            ViewBag.EditoraEditoraId = new SelectList(db.EditorasSet, "EditoraId", "Nome", book.EditoraEditoraId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Titulo,Isbn,DataPublicacao,CategoriaCategoriaId,EditoraEditoraId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaCategoriaId = new SelectList(db.CategoriasSet, "CategoriaId", "Nome", book.CategoriaCategoriaId);
            ViewBag.EditoraEditoraId = new SelectList(db.EditorasSet, "EditoraId", "Nome", book.EditoraEditoraId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.BooksSet.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Book book = db.BooksSet.Find(id);
            db.BooksSet.Remove(book);
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
