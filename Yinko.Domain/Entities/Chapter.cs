using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Common;

namespace Yinko.Domain.Entities
{
    public class Chapter : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public int WordCount { get; set; }

        public string ContenRaw { get; set; } = string.Empty;
        public string ContentCached {  get; set; } = string.Empty;

        public int BookId { get; set; }
        public Book? Book { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
