using Business.Exceptions;
using Models;
using Repositories;
using System.Collections.Generic;

namespace Business
{
	public abstract class ModelHandler<T> where T : BaseModel, new()
	{
		protected IRepository<T> Repository { get; set; }
		public T Entity { get; private set; } = new T();
		public IEnumerable<IValidation<T>> InsertValidations { get; private set; } = new List<IValidation<T>>();
		public ModelHandler(IRepository<T> repository) => Repository = repository;
		public bool Insert()
		{
			var expList = new List<ValidationError>();
			foreach (var validation in InsertValidations)
			{
				try
				{
					validation.Validate(Entity);
				}
				catch (ValidationException ex)
				{
					expList.AddRange(ex.Errors);
				}
			}
			if (expList.Count > 0)
				throw new ValidationException(expList);
			return Repository.Insert(Entity);
		}
		public bool Update() => Repository.Update(Entity);
		public bool Delete() => Repository.Delete(Entity);
		public IEnumerable<T> GetAll() => Repository.GetAll();
		public T GetByID(int id) => Repository.GetByID(id);

		protected void AddInsertValidation(params IValidation<T>[] validations) => (InsertValidations as List<IValidation<T>>).AddRange(validations);
	}
}
