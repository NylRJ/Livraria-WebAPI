using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto01.Models;
using Projeto01.Contexts;

namespace EFCodeFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Objetos
            #region Categoria
            var informatica = new Categoria { CategoriaId = 1, Nome = "Informática" };
            var artesMarciais = new Categoria { CategoriaId = 2, Nome = "Artes Marciais" };
            var ciencias = new Categoria { CategoriaId = 3, Nome = "Ciências" };
            #endregion

            #region Author
            var andre = new Author { AuthorID = 1, FirstName = "André", LastName = "Baltieri", DataNascimento = DateTime.Parse("01/01/2010")};
            andre.Email = string.Format("{0}.{1}@EditoraRio.com", andre.FirstName, andre.LastName);

            var bruce = new Author { AuthorID = 2, FirstName = "Bruce", LastName = " Wayne", DataNascimento = DateTime.Parse("01/02/2009") };
            bruce.Email = string.Format("{0}.{1}@EditoraRio.com", bruce.FirstName, bruce.LastName);

            var peter = new Author { AuthorID = 3, FirstName = "Peter ", LastName = " Parker", DataNascimento = DateTime.Parse("01/03/1980") };
            peter.Email = string.Format("{0}.{1}@EditoraRio.com", peter.FirstName, peter.LastName);

            var tony = new Author { AuthorID = 4, FirstName = "Tony ", LastName = " Stark", DataNascimento = DateTime.Parse("01/04/2018") };
            tony.Email = string.Format("{0}.{1}@EditoraRio.com", tony.FirstName, tony.LastName);

            #endregion

            #region Book
            var devapi = new Book
            {
                
                BookId = 1,
                titulo = "Desenvolvendo APIs com WebApi",
                CategoriaId = 1,
                AnoPublicacao = DateTime.Parse("01/02/1980")
                
            };
            var ninjitsu = new Book
            {
                BookId = 2,
                titulo = "Os segredos do Ninjitsu",
                CategoriaId = 2
            };
            var aranhas = new Book
            {
                BookId = 3,
                titulo = "O segredo das aranhas",
                CategoriaId = 3
            };
            var robotica = new Book
            {
                BookId = 4,
                titulo = "Robótica avançada",
                CategoriaId = 3
            };
            #endregion

            #endregion

            #region Context
            using (EFContext db = new EFContext())
            {
                db.Categorias.Add(informatica);
                db.Categorias.Add(artesMarciais);
                db.Categorias.Add(ciencias);

                db.Authors.Add(andre);
                db.Authors.Add(bruce);
                db.Authors.Add(peter);
                db.Authors.Add(tony);

                db.Books.Add(devapi);
                db.Books.Add(ninjitsu);
                db.Books.Add(aranhas);
                db.Books.Add(robotica);

                devapi.Authors.Add(andre);
                devapi.Authors.Add(tony);
                devapi.Authors.Add(bruce);

                ninjitsu.Authors.Add(bruce);
                devapi.Authors.Add(tony);

                aranhas.Authors.Add(peter);
                devapi.Authors.Add(tony);

                robotica.Authors.Add(tony);

                db.SaveChanges();
            }
            #endregion

            #region Categorias
            using (EFContext db = new EFContext())
            {
                Console.WriteLine("Categorias");
                foreach (Categoria categoria in db.Categorias)
                {
                    Console.WriteLine(
                        String.Format("{0} - {1}", 
                            categoria.CategoriaId, 
                            categoria.Nome));
                }
            }
            #endregion

            Console.WriteLine(Environment.NewLine);

            #region Authors
            using (EFContext db = new EFContext())
            {
                Console.WriteLine("Authors");
                foreach (Author Author in db.Authors)
                {
                    Console.WriteLine(
                        String.Format("{0} - {1}",
                            Author.AuthorID,
                            Author.FirstName,
                            Author.LastName,
                            Author.DataNascimento,
                            Author.Email));
                }
            }
            #endregion

            Console.WriteLine(Environment.NewLine);

            #region Books
            using (EFContext db = new EFContext())
            {
                Console.WriteLine("Books");
                foreach (Book Book in db.Books)
                {
                    Console.WriteLine(
                        String.Format("{0} - {1}",
                            Book.BookId,
                            Book.titulo));
                }
            }
            #endregion

            Console.WriteLine(Environment.NewLine);

            #region Tudo
            using (EFContext db = new EFContext())
            {
                Console.WriteLine("Tudo");
                foreach (Categoria categoria in
                    db.Categorias.Include("Books")
                                 .Include("Books.Authors")
                                 .ToList())
                {
                    Console.WriteLine("Categoria: " + categoria.Nome);
                    foreach (Book Book in categoria.Books)
                    {
                        Console.WriteLine("\tBook: " + Book.titulo);
                        foreach (Author Author in Book.Authors)
                        {
                            Console.WriteLine("\t\tAuthor: " + Author.FirstName," "+Author.LastName);
                        }
                    }
                    Console.WriteLine(Environment.NewLine);
                }
            }
            #endregion

            Console.ReadKey();
        }
    }
} 