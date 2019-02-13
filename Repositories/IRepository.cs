using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IRepository<T> where T : BaseModel
	{
		IEnumerable<T> GetAll();
		T GetByID(int ID);
		bool Insert(T entry);
		bool Update(T entry);
		bool Delete(T entry);
	}
}
