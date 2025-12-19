using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Common;

namespace Yinko.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool IsNsfw { get; set; }
        
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
