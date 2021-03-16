using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TruthOrDare.Domain.Entities.Models;
using TruthOrDare.Infra.Mapping;

namespace TruthOrDare.Infra.Context
{
    public class DataContext : DbContext
    {
        #region Constructors

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        // : base("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=truthordare;Data Source=DESKTOP-8QPURBN")
        #endregion

        #region Table
        public DbSet<User> User { get; set; }
        public DbSet<Truth> Truth { get; set; }
        public DbSet<Dare> Dare { get; set; }
        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Map
            builder.ApplyConfiguration(new UserMapper());
            builder.ApplyConfiguration(new TruthMapper());
            builder.ApplyConfiguration(new DareMapper()); 
            #endregion


        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors) // <-- Coloque um Breakpoint aqui para conferir os erros de validação.
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (DbUpdateException e)
            {
                foreach (var eve in e.Entries)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entity.GetType().Name, eve.State);
                }
                throw;
            }
            catch (SqlException s)
            {
                Console.WriteLine("- Message: \"{0}\", Data: \"{1}\"",
                    s.Message, s.Data);
                throw;
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion
    }
}
