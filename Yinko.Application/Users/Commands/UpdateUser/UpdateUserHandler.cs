using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Application.Common.Interfaces;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;
using Yinko.Domain.Entities;

namespace Yinko.Application.Books.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(DomainErrors.User.NotFound, nameof(User), request.Id);
            }

            // TODO: fix Bio nullability issue
            user.UpdateProfile(request.Username, user.Bio, request.AvatarUrl);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
