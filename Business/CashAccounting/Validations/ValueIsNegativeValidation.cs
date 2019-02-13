using Business.Exceptions;

namespace Business.CashAccounting.Validations
{
	public class ValueIsNegativeValidation : IValidation<Models.CashAccounting>
	{
		public void Validate(Models.CashAccounting entity)
		{
			if (entity.Value <= 0)
				throw new ValidationException(new ValidationError { Description = "مبلغ ارز باید بزرگتر از صفر باشد", FieldName = "Value" });
		}
	}
}
