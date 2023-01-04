using DataAccess.EntityFramework.Concrete;
using DataAccess.EntityFramework.Context;
using Hastane.DataAccess.Abstract;
using Hastane.Entities.Abstract;
using Hastane.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Concrete
{
	public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
	{
		public EmployeeRepo(HastaneDbContext hastaneDbContext) : base(hastaneDbContext)
		{
		}
	}
}
