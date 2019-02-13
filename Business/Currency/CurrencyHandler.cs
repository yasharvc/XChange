using Repositories;
using Repositories.Abstracts;
using System.Collections.Generic;

namespace Business.Currency
{
	public class CurrencyHandler : ModelHandler<Models.Currency>
	{
		public CurrencyHandler() : base(RepositoryProvider.GetCurrencyRepository()) { }
		public CurrencyHandler(IRepository<Models.Currency> repository) : base(repository) { }

		public IEnumerable<Models.Currency> GetAllActive() => (Repository as CurrencyRepository).GetAllActive();
	}
}
