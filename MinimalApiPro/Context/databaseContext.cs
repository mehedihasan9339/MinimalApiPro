using Microsoft.EntityFrameworkCore;
using MinimalApiPro.Data;

namespace MinimalApiPro.Context
{
	public class databaseContext:DbContext
	{
		public databaseContext(DbContextOptions<databaseContext> options):base(options)
		{

		}
		public DbSet<EmployeeInfo> employeeInfos { get; set; }
	}
}
