using MediatR;
using Yinko.Application.Common.Interfaces;
using Yinko.Application.Common.Models;
using Yinko.Domain.Common.Exceptions;
using Yinko.Domain.Entities;

namespace Yinko.Application.Users.Queries.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IApplicationDbContext _context;

        public GetUserHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FindAsync([request.Id], cancellationToken);

            if (user == null)
            {
                throw new NotFoundException("User not found", nameof(User), request.Id);
            }

            // TODO: Change to AutoMapper mapping eventually :3

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                AvatarUrl = user.AvatarUrl // TODO: Handle potential null value appropriately
            };
        }
    }
}
