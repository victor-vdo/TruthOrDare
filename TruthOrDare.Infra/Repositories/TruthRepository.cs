using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Infra.Context;

namespace TruthOrDare.Infra.Repositories
{
    public class TruthRepository : Repository<Truth>, ITruthRepository
    {
        #region Constructors

        public TruthRepository(DataContext context) : base(context) { }

        #endregion               
    }
}
