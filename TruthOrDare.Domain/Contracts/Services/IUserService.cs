using System;
using TruthOrDare.Domain.Commands.User;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Contracts.Services
{
    public interface IUserService
    {
        User GetById(Guid id);
        void Add(UserAddCommand command);
        void UpdatePassword(UserUpdatePasswordCommand command);
        void Delete(UserDeleteCommand command);
    }
}
