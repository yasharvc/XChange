using Business.Exceptions;

namespace Business.CashAccounting.Validations
{
	public class RialPriceIsNegativeValidation : IValidation<Models.CashAccounting>
	{
		public void Validate(Models.CashAccounting entity)
		{
			if (entity.CurrencyValueInRial <= 0)
				throw new ValidationException(new ValidationError { Description = "مبلغ ریالی باید بزرگتر از صفر باشد", FieldName = "Value" });
		}
	}
}
