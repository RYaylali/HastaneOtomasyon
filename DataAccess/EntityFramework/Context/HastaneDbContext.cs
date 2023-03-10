using Hastane.DataAccess.EntityFramework.Mapping;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Context
{
	public class HastaneDbContext:DbContext
	{
		public HastaneDbContext(DbContextOptions<HastaneDbContext> options):base(options) 
		{

		}
	
		public DbSet<User> Admins { get; set; }
		public DbSet<Employee> Employees { get; set; }		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AdminMapping())
				.ApplyConfiguration(new EmployeeMapping());
				
			base.OnModelCreating(modelBuilder);
		}
	}
	
}
