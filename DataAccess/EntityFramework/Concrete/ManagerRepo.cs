using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Concrete
{
	public class ManagerRepo : BaseRepo<Manager>, ImanagerRepo
	{
		public ManagerRepo(HastaneDbContext hastaneDbContext) : base(hastaneDbContext)
		{
		}
		public async Task<Manager> GetByEmail(string email, string password)
		{
			var manager = await _table.Where(x => x.EmailAddress == email && x.Password == password).FirstOrDefaultAsync();
			return manager;
		}
	}
}
