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
				dbContext.Admins.Add(new Admin()
				{
					Id=Guid.NewGuid(),
					Name="ramazan",
					Surname="yaylalı",
					EmailAddress="ryaylali97@gmail.com",
					Status=Status.Active,
					Password="1234",
					CreatedDate=DateTime.Now,
				});
			}
			dbContext.SaveChanges();
		}
	}
}
