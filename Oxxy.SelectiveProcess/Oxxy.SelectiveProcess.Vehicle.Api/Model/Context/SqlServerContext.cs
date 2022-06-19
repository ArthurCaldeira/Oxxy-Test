using Microsoft.EntityFrameworkCore;

namespace Oxxy.SelectiveProcess.Vehicle.Api.Model.Context
{
    public class SqlServerContext: DbContext
    {
        public SqlServerContext() { }

        public SqlServerContext(DbContextOptions<SqlServerContext> option): base(option) { }

        public DbSet<Vehicle> Vehicles { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
