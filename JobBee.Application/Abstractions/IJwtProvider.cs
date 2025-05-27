using JobBee.Api.Models;

namespace JobBee.Application.Abstractions
{
	public interface IJwtProvider
	{
		string Generate(User user);
	}
}
