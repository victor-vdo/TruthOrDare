using System.Collections.Generic;
using System.Linq;
using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Domain.Enums;
using TruthOrDare.Infra.Context;

namespace TruthOrDare.Infra.Repositories
{
    public class DareRepository : Repository<Dare>, IDareRepository
    {
        #region Constructors

        public DareRepository(DataContext context) : base(context) { }

        #endregion               

        public List<Dare> GetDareListByType(ETruthOrDareType type)
        {
            var list = _context.Set<Dare>().Where(w => w.Type == type).ToList();
            return list;
        }
    }
}
