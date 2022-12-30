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
	public class PersonnelRepo : BaseRepo<Personnel>, IPersonnelRepo
	{
		public PersonnelRepo(HastaneDbContext hastaneDbContext) : base(hastaneDbContext)
		{
		}
		public async Task<Personnel> GetByEmail(string email, string password)
		{
			var personnel = await _table.Where(x => x.EmailAddress == email && x.Password == password).FirstOrDefaultAsync();
			return personnel;
		}
	}
}
