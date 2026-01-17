using MediatR;
using Yinko.Application.Common.Models;


namespace Yinko.Application.Users.Commands.LoginUser
{
    public record LoginUserCommand(string IdentityId) : IRequest<UserDto>;
}