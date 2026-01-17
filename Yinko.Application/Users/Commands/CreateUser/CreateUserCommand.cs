using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(string IdentityId, string Username, string Email, string? AvatarUrl) : IRequest<int>;
}