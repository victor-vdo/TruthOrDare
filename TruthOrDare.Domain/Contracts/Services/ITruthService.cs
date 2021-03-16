using System;
using TruthOrDare.Domain.Commands.Truth;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Contracts.Services
{
    public interface ITruthService
    {
        Truth GetById(Guid id);
        void Add(TruthAddCommand command);
        void Update(TruthUpdateCommand command);
        void Delete(TruthDeleteCommand command);
    }
}
