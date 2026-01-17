using MediatR;

namespace Yinko.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(int Id) : IRequest<Unit>;
}
