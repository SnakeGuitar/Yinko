using MediatR;

namespace Yinko.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(int Id, string Username, string AvatarUrl) : IRequest<Unit>;
}