using Livraria.DomainModel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.DataAccess.Contexts
{
    public class EFContext : DbContext
    {

        public EFContext() : base(Livraria.DataAccess.Properties.Settings.Default.LivrarioInfoRio1)
        {
            //Database.SetInitializer<EFContext>(new EFContextInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> CategoriasSet { get; set; }
        public DbSet<Editora> EditorasSet { get; set; }
        public DbSet<Author> AuthorsSet { get; set; }
        public DbSet<Book> BooksSet { get; set; }
        public DbSet<BookAuthor> BookAuthorsSet { get; set; }


    }
    public class EFContextInitializer : DropCreateDatabaseAlways<EFContext>
    {
    }
}
