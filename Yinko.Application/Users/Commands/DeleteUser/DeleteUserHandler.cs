using MediatR;
using Yinko.Application.Common.Interfaces;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;

namespace Yinko.Application.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeleteUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(DomainErrors.User.NotFound, nameof(Domain.Entities.User), request.Id);
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
