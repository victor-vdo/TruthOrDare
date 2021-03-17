using System;
using TruthOrDare.Domain.Commands.Truth;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Contracts.Services
{
    public interface ITruthService
    {
        ICommandResult GetById(Guid id);
        ICommandResult Add(TruthAddCommand command);
        ICommandResult Update(TruthUpdateCommand command);
        ICommandResult Delete(TruthDeleteCommand command);
    }
}
