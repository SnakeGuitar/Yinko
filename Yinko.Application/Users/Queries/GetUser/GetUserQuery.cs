using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Application.Common.Models;

namespace Yinko.Application.Users.Queries.GetUser
{
    public record GetUserQuery(int Id) : IRequest<UserDto>;
}
