using Hastane.Core.Entities.Abstract;

namespace DataAccess.EntityFramework.Concrete
{
	public interface IBaseEntity<T> where T : class, IBaseEntity
	{
	}
}