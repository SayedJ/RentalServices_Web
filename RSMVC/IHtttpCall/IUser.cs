using System;
using RSMVC.Models;

namespace RSMVC.IHtttpCall
{
	public interface IUser
	{
		Task<ApplicationUser> Register(ApplicationUser user);

		Task Login(LoginUserDto userLogin);



	}
}

