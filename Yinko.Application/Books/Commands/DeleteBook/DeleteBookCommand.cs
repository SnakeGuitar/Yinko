using MediatR;

namespace Yinko.Application.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(int Id) : IRequest<Unit>;
}