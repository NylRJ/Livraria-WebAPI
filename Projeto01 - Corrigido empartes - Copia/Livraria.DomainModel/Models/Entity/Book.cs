using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.DomainModel.Models.Entity
{
    public  class Book
    {



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.BookAuthor = new HashSet<BookAuthor>();
        }

        public System.Guid BookId { get; set; }
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public System.DateTime DataPublicacao { get; set; }
        public System.Guid CategoriaCategoriaId { get; set; }
        public System.Guid EditoraEditoraId { get; set; }

        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
        public virtual Editora Editora { get; set; }

    }
}
