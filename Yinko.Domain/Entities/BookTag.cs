using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Domain.Entities
{
    public class BookTag
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
