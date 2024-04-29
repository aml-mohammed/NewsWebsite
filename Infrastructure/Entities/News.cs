using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class News:BaseEntity
    {
       
        public string Title { get; set; } = null!;
        public string NewsBody { get; set; } = null!;
        public string Image { get; set; } = null!;
        public DateTime? PublicationDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
