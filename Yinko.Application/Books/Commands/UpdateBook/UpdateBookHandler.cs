using MediatR;
using Yinko.Application.Common.Interfaces;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;
using Yinko.Domain.Entities;

namespace Yinko.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBookHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { request.Id }, cancellationToken);

            if (book == null)
            {
                throw new NotFoundException(DomainErrors.Book.NotFound, nameof(Book), request.Id);
            }

            book.Update(request.Title, request.Synopsis);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
