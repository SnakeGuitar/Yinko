using MediatR;
using Yinko.Application.Common.Models;

namespace Yinko.Application.Books.Queries.GetBook
{
    public record GetBookQuery(int Id) : IRequest<BookDto>;
}
