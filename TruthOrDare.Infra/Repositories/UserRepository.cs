using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Infra.Context;

namespace TruthOrDare.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(DataContext context) : base(context) { }

        #endregion               
    }
}
