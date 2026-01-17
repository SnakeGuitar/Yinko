using MediatR;
using Microsoft.EntityFrameworkCore;
using Yinko.Application.Common.Interfaces;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;
using Yinko.Domain.Entities;

namespace Yinko.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            bool emailExists = await _context.Users
                .AnyAsync(u => u.Email == request.Email, cancellationToken);

            if (emailExists)
            {
                throw new InvalidUserException(DomainErrors.User.EmailDuplicate, "Email already in use");
            }
            
            var usernameExists = await _context.Users
                .AnyAsync(u => u.Username == request.Username, cancellationToken);

            if (usernameExists)
            {
                throw new InvalidUserException(DomainErrors.User.UsernameDuplicate, "Username already in use");
            }

            var user = User.Create(
                request.IdentityId,
                request.Username,
                request.Email
            );

            if (!string.IsNullOrEmpty(request.AvatarUrl))
            {
                user.UpdateProfile(request.Username, user.Bio, request.AvatarUrl);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
