using System;
using TruthOrDare.Domain.Commands.User;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Contracts.Services
{
    public interface IUserService
    {
        User GetUserById(Guid id);
        void Add(UserAddCommand command);
        void UpdatePassword(UserUpdatePasswordCommand command);
        void Delete(UserAddCommand command);
    }
}
