using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.DomainModel.Models.Entity
{
    public class Author
    {


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            this.BookAuthor = new HashSet<BookAuthor>();
        }

        public System.Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AuthorName { get{ return FirstName + " " + LastName; }  }
        public System.DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
    }
}