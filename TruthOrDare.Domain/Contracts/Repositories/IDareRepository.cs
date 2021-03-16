using System.Collections.Generic;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Domain.Enums;

namespace TruthOrDare.Domain.Contracts.Repositories
{
    public interface IDareRepository : IRepository<Dare>
    {
        List<Dare> GetDareListByType(ETruthOrDareType type);
    }
}
