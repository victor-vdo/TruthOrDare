using System;
using System.Collections.Generic;
using TruthOrDare.Domain.Commands;
using TruthOrDare.Domain.Commands.Dare;
using TruthOrDare.Domain.Contracts;
using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Contracts.Services;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Domain.Enums;

namespace DareOrDare.Domain.Services
{
    public class DareService : IDareService
    {
        private readonly IDareRepository _dareRepository;
        public DareService(IDareRepository dareRepository)
        {
            _dareRepository = dareRepository;
        }

        public ICommandResult GetById(Guid id)
        {
            try
            {
                var dare = _dareRepository.Read(id);
                if (dare == null)
                    return new CommandResult("Desafio não encontrado!", null, false);
                var commandResult = new CommandResult("Busca desafio pelo ID realizada com sucesso!",dare,false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }
        public ICommandResult GetByType(int type)
        {
            try
            {
                var EType = (ETruthOrDareType)type;
                var list = _dareRepository.GetDareListByType(EType);
                var commandResult = new CommandResult("Busca de desafio pelo tipo realizada com sucesso!", list, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Add(DareAddCommand command)
        {
            try
            {
                var dare = new Dare { Description = command.Description, Type = command.Type };
                _dareRepository.Create(dare);
                var commandResult = new CommandResult("Desafio adicionado com sucesso!", null, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Update(DareUpdateCommand command)
        {
            try
            {
                var dare = _dareRepository.Read(command.Id);
                dare.Type = command.Type;
                dare.Description = command.Description;
                _dareRepository.Update(dare);
                var commandResult = new CommandResult("Desafio atualizado com sucesso!", dare, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Delete(DareDeleteCommand command)
        {
            try
            {
                var dare = _dareRepository.Read(command.Id);
                _dareRepository.Delete(dare);
                var commandResult = new CommandResult("Desafio deletado com sucesso!", dare, false);
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
