using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruthOrDare.Domain.Commands.User;
using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Contracts.Services;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Domain.Utils;

namespace TruthOrDare.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(Guid id)
        {
            try
            {
                var user = _userRepository.Read(id);
                return user;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Get User By Id Error");
            }
        }

        public void Add(UserAddCommand command)
        {
            try
            {
                var user = new User { Login = command.Login, Password = command.Password };
                user.Password = Encrypt.Password(command.Password);
                _userRepository.Create(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdatePassword(UserUpdatePasswordCommand command)
        {
            try
            {
                if(command.Password == command.ConfirmPassword)
                {
                    var user = _userRepository.Read(command.Id);
                    user.Password = Encrypt.Password(command.Password);
                    _userRepository.Update(user);
                }
                else
                {
                    throw new ArgumentException("Password and Confirm Password not match");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(UserDeleteCommand command)
        {
            try
            {
                var user = _userRepository.Read(command.Id);
                _userRepository.Delete(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
