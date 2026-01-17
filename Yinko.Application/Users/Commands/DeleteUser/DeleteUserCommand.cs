using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Application.Books.Commands.DeleteUser
{
    public record DeleteUserCommand(int Id) : IRequest<Unit>;
}
