using System;
using System.Collections.Generic;

namespace Business.Exceptions
{
	public class ValidationException : Exception
	{
		public IEnumerable<ValidationError> Errors { get; set; }
		public ValidationException(IEnumerable<ValidationError> errors)
		{
			Errors = errors;
		}

		public ValidationException(ValidationError error)
		{
			Errors = new List<ValidationError> { error };
		}
	}
}
