using System.Collections.Generic;


namespace Livraria.DomainModel.Models.Entity
{
    public class Categoria
    {


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            this.Book = new HashSet<Book>();
        }

        public System.Guid CategoriaId { get; set; }
        
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Book { get; set; }

    }
}
