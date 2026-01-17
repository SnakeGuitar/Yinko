using MediatR;
using Microsoft.EntityFrameworkCore;
using Yinko.Application.Common.Interfaces;
using Yinko.Application.Common.Models;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;

namespace Yinko.Application.Books.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserDto>
    {
        private readonly IApplicationDbContext _context;
        public LoginUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.Books)
                .FirstOrDefaultAsync(u => u.IdentityId == request.IdentityId, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(DomainErrors.User.NotFound, "Identity", request.IdentityId);
            }

            user.RegisterLogin();
            await _context.SaveChangesAsync(cancellationToken);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                Bio = user.Bio,
                InkosBalance = user.InkosBalance,
                CurrentStreak = user.CurrentStreak,
                CriticScore = user.CriticScore,
                PublishedBooks = user.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Synopsis = b.Synopsis
                }).ToList()
            };
        }
    }
}
