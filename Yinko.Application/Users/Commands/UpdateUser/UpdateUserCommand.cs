using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Application.Books.Commands.UpdateUser
{
    public record UpdateUserCommand(int Id, string Username, string AvatarUrl) : IRequest<Unit>;
}
