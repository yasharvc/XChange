using Repositories;
using Repositories.Abstracts;

namespace Business.User
{
	public class UserHandler : ModelHandler<Models.User>
	{
		public UserHandler():base(RepositoryProvider.GetUserRepository()) { }

		public Models.User GetUserByUsernamePassword(string username,string password)
		{
			return (Repository as UserRepository).GetByUserName(username, password);
		}
	}
}
