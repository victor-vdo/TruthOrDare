using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Infra.DataContext
{
    public class EntityFramework : DbContext
    {
        #region Constructors

        static EntityFramework()
        {
            Database.SetInitializer<EntityFramework>(null);
        }

#if DEBUG
        public EntityFramework()
                      : base("Data Source=luby-win-hml.southcentralus.cloudapp.azure.com;Initial Catalog=seichoEventosHom31;Persist Security Info=True;User ID=luby-mssql;Password=0o%2Hvv!6iBF;MultipleActiveResultSets=True")
        //          : base("Data Source=svrdbsni.database.windows.net;Initial Catalog=DBeventos;Persist Security Info=True;User ID=admindb;Password=SeichO@2019;MultipleActiveResultSets=True")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
#else
                                     public EntityFramework() : base("Data Source=luby-win-hml.southcentralus.cloudapp.azure.com;Initial Catalog=seichoEventosHom31;Persist Security Info=True;User ID=seicho;Password=luby-s31ch0%;MultipleActiveResultSets=True"){}
               //                     public EntityFramework() : base("Data Source=svrdbsni.database.windows.net;Initial Catalog=DBeventos;Persist Security Info=True;User ID=admindb;Password=SeichO@2019;MultipleActiveResultSets=True"){}
        
#endif

        #endregion

        #region Map

        public DbSet<User> User { get; set; }
       
        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>().ToTable("User");
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Created").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Updated") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Updated").CurrentValue = DateTime.Now;
                }
            }

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

        #endregion
    }
}
