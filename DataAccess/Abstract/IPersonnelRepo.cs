using Hastane.Core.DataAccess.Abstract;
using Hastane.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IPersonnelRepo:IBaseRepo<Personnel>
	{
		Task<Personnel> GetByEmail(string email, string password);
	}
}
