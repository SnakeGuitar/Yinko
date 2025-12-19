using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}
