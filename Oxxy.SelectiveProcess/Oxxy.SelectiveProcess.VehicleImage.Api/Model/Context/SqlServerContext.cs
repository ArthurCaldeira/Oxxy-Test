using Microsoft.EntityFrameworkCore;

namespace Oxxy.SelectiveProcess.VehicleImage.Api.Model.Context
{
    public class SqlServerContext: DbContext
    {
        public SqlServerContext() { }

        public SqlServerContext(DbContextOptions<SqlServerContext> option) : base(option) { }

        public DbSet<VehicleImage> VehicleImages { get; set; }
    }
}
