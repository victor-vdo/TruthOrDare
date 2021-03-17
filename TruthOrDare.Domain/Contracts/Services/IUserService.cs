using System;
using TruthOrDare.Domain.Commands.User;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Contracts.Services
{
    public interface IUserService
    {
        ICommandResult GetById(Guid id);
        ICommandResult Add(UserAddCommand command);
        ICommandResult UpdatePassword(UserUpdatePasswordCommand command);
        ICommandResult Delete(UserDeleteCommand command);
    }
}
