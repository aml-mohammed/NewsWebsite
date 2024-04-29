using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Author:BaseEntity
    {
       
        public string AuthorName { get; set; } = null!;
      //  public ICollection<News> News { get; set; } = new HashSet<News>();
    }
}
