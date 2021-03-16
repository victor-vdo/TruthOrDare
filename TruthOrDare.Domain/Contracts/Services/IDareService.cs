using System;
using System.Collections.Generic;
using TruthOrDare.Domain.Commands.Dare;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Domain.Contracts.Services
{
    public interface IDareService
    {
        Dare GetById(Guid id);
        List<Dare> GetByType(int type);
        void Add(DareAddCommand command);
        void Update(DareUpdateCommand command);
        void Delete(DareDeleteCommand command);
    }
}
