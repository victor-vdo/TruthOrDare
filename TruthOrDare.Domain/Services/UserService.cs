using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruthOrDare.Domain.Commands;
using TruthOrDare.Domain.Commands.User;
using TruthOrDare.Domain.Contracts;
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

        public ICommandResult GetById(Guid id)
        {
            try
            {
                var user = _userRepository.Read(id);
                if(user == null)
                    return new CommandResult("Usuário não encontrado!", null, false);
                var commandResult = new CommandResult("Busca de usuário pelo ID realizada com sucesso!", user, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Add(UserAddCommand command)
        {
            try
            {
                var user = new User { Login = command.Login, Password = command.Password };
                user.Password = Encrypt.Password(command.Password);
                _userRepository.Create(user);
                var commandResult = new CommandResult("Usuário adicionado com sucesso!", user, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult UpdatePassword(UserUpdatePasswordCommand command)
        {
            try
            {
                if(command.Password == command.ConfirmPassword)
                {
                    var user = _userRepository.Read(command.Id);
                    user.Password = Encrypt.Password(command.Password);
                    _userRepository.Update(user);
                    var commandResult = new CommandResult("Senha atualizada com sucesso!", user, false);
                    return commandResult;
                }
                else
                {
                    var commandResult = new CommandResult($"Senha e confirmação de senha não são iguais !", null, false);
                    return commandResult;
                }
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Delete(UserDeleteCommand command)
        {
            try
            {
                var user = _userRepository.Read(command.Id);
                _userRepository.Delete(user);
                var commandResult = new CommandResult("Usuário deletado com sucesso!", user, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }
    }
}
