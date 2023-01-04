using DataAccess.EntityFramework.Context;
using Hastane.Core.Enums;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace NRM1_HastaneOtomasyon.Models.SeedData
{
	public static class SeedData
	{	
		//programcs dosyasında bulunan app ile aynı olacak
		public static void Seed(IApplicationBuilder app)
		{
			var scope = app.ApplicationServices.CreateScope();
			var dbContext = scope.ServiceProvider.GetService<HastaneDbContext>();
			dbContext.Database.Migrate();
			if (dbContext.Admins.Count()==0)
			{
				dbContext.Admins.Add(new User()
				{
					Id=Guid.NewGuid(),
					Name="ramazan",
					Surname="yaylalı",
					EmailAddress="ryaylali97@gmail.com",
					Status=Status.Active,
					Password="1234",
					CreatedDate=DateTime.Now,
					Roles=Roles.Admin,
				});

			}
			if (dbContext.Employees.Count() == 0)
			{
				dbContext.Employees.Add(new Employee()
				{
					Id = Guid.NewGuid(),
					Name = "fatih",
					Surname = "bag",
					EmailAddress = "fatih96@gmail.com",
					Status = Status.Active,
					Password = "1234",
					Salary=150000,
					IdentityNumber="4145412",
					CreatedDate = DateTime.Now,
					Roles = Roles.Manager,
				});

			}
			dbContext.SaveChanges();
		}
	}
}
