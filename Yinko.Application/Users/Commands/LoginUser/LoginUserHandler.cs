using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Yinko.Application.Common.Interfaces;
using Yinko.Application.Common.Models;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;

namespace Yinko.Application.Users.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LoginUserHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync
                (u => u.Email == request.Email, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(
                code: "User.NotFound",
                name: nameof(user),
                key: request.Email
            );
            }

            user.RegisterLogin();
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserDto>(user);
        }
    }
}
