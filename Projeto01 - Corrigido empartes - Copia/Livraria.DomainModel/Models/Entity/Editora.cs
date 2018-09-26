using System.Collections.Generic;

namespace Livraria.DomainModel.Models.Entity
{
    public class Editora
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Editora()
        {
            this.Book = new HashSet<Book>();
        }

        public System.Guid EditoraId { get; set; }
        
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Book { get; set; }

    }
}
