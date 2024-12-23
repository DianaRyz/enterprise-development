using TaxiCompany.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaxiCompany.EfCore
{
    /// <summary>
    /// Фабрика для создания экземпляра контекста TaxiCompanyContext во время выполнения команд EF Core
    /// </summary>
    public class TaxiCompanyDbContextFactory : IDesignTimeDbContextFactory<TaxiCompanyContext>
    {
        /// <summary>
        /// Создает экземпляр контекста базы данных для использования во время разработки.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        /// <returns>Экземпляр контекста TaxiCompanyContext</returns>
        public TaxiCompanyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxiCompanyContext>();

            optionsBuilder.UseMySql(
                "server=localhost; port=3306; uid=root; pwd=Rizik_30042003; database=taxicompany",
                new MySqlServerVersion(new Version(8, 0, 2))
            );

            return new TaxiCompanyContext(optionsBuilder.Options);
        }
    }
}