using System;
using TruthOrDare.Domain.Commands.Dare;

namespace TruthOrDare.Domain.Contracts.Services
{
    public interface IDareService
    {
        ICommandResult GetById(Guid id);
        ICommandResult GetByType(int type);
        ICommandResult Add(DareAddCommand command);
        ICommandResult Update(DareUpdateCommand command);
        ICommandResult Delete(DareDeleteCommand command);
    }
}
