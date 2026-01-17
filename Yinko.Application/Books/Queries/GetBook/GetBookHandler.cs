using MediatR;
using Yinko.Application.Books.Queries.GetBook;
using Yinko.Application.Common.Interfaces;
using Yinko.Application.Common.Models;
using Yinko.Domain.Common.Exceptions;
using Yinko.Domain.Entities;
public class GetBookHandler : IRequestHandler<GetBookQuery, BookDto>
{
    private readonly IApplicationDbContext _context;

    public GetBookHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Books
            .FindAsync([request.Id], cancellationToken);

        if (book == null)
        {
            throw new NotFoundException("Book not found", nameof(Book), request.Id);
        }

        // TODO: Change to AutoMapper mapping eventually :3

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Synopsis = book.Synopsis
        };
    }
}