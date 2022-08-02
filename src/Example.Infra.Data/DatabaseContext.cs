using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Stefanini.Challenge.Domain.Data;
using Stefanini.Challenge.Domain.Entities;

namespace Stefanini.Challenge.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        public DatabaseContext(DbContextOptions options) 
            : base(options)
        { }
        public DbSet<City> City { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

        }

        public async Task<bool> Commit()
        {
            try
            {
                return await base.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }

}
