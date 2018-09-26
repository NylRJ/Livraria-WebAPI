using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.DomainModel.Models.Entity
{
    public class BookAuthor
    {
        public System.Guid BookAuthorId { get; set; }
        public System.Guid BookBookId { get; set; }
        public System.Guid AuthorAuthorId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}