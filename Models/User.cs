using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public enum UserType : int
	{
		Operator = 1,
		Manager = 2
	}
	public class User : BaseModel
	{
		public int ID { get; set; }

		public string UserName { get; set; }

		public byte[] Password { get; set; }

		public string FullName { get; set; }

		public UserType UserType { get; set; }

	}
}
