using MediatR;
using Yinko.Application.Common.Interfaces;
using Yinko.Domain.Entities;

namespace Yinko.Application.Books.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var book = Book.Create(request.Title, request.Synopsis, request.AuthorId);

            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);

            // TODO: Add email notification to author about book creation

            return book.Id;
        }
    }
}