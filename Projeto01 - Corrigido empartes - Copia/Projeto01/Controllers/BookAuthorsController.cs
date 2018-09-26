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
    public class BookAuthorsController : Controller
    {
        private EFContext db = new EFContext();

        // GET: BookAuthors
        public ActionResult Index()
        {
            var bookAuthorsSet = db.BookAuthorsSet.Include(b => b.Author).Include(b => b.Book);
            return View(bookAuthorsSet.ToList());
        }

        // GET: BookAuthors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthor bookAuthor = db.BookAuthorsSet.Find(id);
            if (bookAuthor == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthor);
        }

        // GET: BookAuthors/Create
        public ActionResult Create()
        {
            ViewBag.AuthorAuthorId = new SelectList(db.AuthorsSet, "AuthorId", "FirstName");
            ViewBag.BookBookId = new SelectList(db.BooksSet, "BookId", "Titulo");
            return View();
        }

        // POST: BookAuthors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookAuthorId,BookBookId,AuthorAuthorId")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                bookAuthor.BookAuthorId = Guid.NewGuid();
                db.BookAuthorsSet.Add(bookAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorAuthorId = new SelectList(db.AuthorsSet, "AuthorId", "FirstName", bookAuthor.AuthorAuthorId);
            ViewBag.BookBookId = new SelectList(db.BooksSet, "BookId", "Titulo", bookAuthor.BookBookId);
            return View(bookAuthor);
        }

        // GET: BookAuthors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthor bookAuthor = db.BookAuthorsSet.Find(id);
            if (bookAuthor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorAuthorId = new SelectList(db.AuthorsSet, "AuthorId", "FirstName", bookAuthor.AuthorAuthorId);
            ViewBag.BookBookId = new SelectList(db.BooksSet, "BookId", "Titulo", bookAuthor.BookBookId);
            return View(bookAuthor);
        }

        // POST: BookAuthors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookAuthorId,BookBookId,AuthorAuthorId")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorAuthorId = new SelectList(db.AuthorsSet, "AuthorId", "FirstName", bookAuthor.AuthorAuthorId);
            ViewBag.BookBookId = new SelectList(db.BooksSet, "BookId", "Titulo", bookAuthor.BookBookId);
            return View(bookAuthor);
        }

        // GET: BookAuthors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthor bookAuthor = db.BookAuthorsSet.Find(id);
            if (bookAuthor == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthor);
        }

        // POST: BookAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BookAuthor bookAuthor = db.BookAuthorsSet.Find(id);
            db.BookAuthorsSet.Remove(bookAuthor);
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
