using MediatR;
using Yinko.Application.Common.Interfaces;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;
using Yinko.Domain.Entities;

namespace Yinko.Application.Books.Commands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBookHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { request.Id }, cancellationToken);

            if (book == null)
            {
                throw new NotFoundException(DomainErrors.Book.NotFound, nameof(Book), request.Id);
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
