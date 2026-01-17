using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Application.Common.Models;


namespace Yinko.Application.Users.Commands.LoginUser
{
    public record LoginUserCommand(string IdentityId) : IRequest<UserDto>;
}