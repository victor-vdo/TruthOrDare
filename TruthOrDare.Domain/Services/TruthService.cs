using System;
using TruthOrDare.Domain.Commands;
using TruthOrDare.Domain.Commands.Truth;
using TruthOrDare.Domain.Contracts;
using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Contracts.Services;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Services
{
    public class TruthService : ITruthService
    {
        private readonly ITruthRepository _truthRepository;
        public TruthService(ITruthRepository truthRepository)
        {
            _truthRepository = truthRepository;
        }

        public ICommandResult GetById(Guid id)
        {
            try
            {
                var truth = _truthRepository.Read(id);
                if (truth == null)
                    return new CommandResult("Verdade não encontrada!", null, false);
                var commandResult = new CommandResult("Busca de verdade pelo ID realizada com sucesso!", truth, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Add(TruthAddCommand command)
        {
            try
            {
                var truth = new Truth {Description = command.Description, Type = command.Type };
                _truthRepository.Create(truth);
                var commandResult = new CommandResult("Verdade adicionada com sucesso!", truth, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Update(TruthUpdateCommand command)
        {
            try
            {
                var truth = _truthRepository.Read(command.Id);
                truth.Type = command.Type;
                truth.Description = command.Description;
                _truthRepository.Update(truth);
                var commandResult = new CommandResult("Verdade atualizada com sucesso!", truth, false);
                return commandResult;
            }
            catch (Exception ex)
            {
                var commandResult = new CommandResult($"{ex.InnerException.Message}", null, true);
                return commandResult;
            }
        }

        public ICommandResult Delete(TruthDeleteCommand command)
        {
            try
            {
                var truth = _truthRepository.Read(command.Id);
                _truthRepository.Delete(truth);
                var commandResult = new CommandResult("Verdade deletada com sucesso!", null, false);
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
