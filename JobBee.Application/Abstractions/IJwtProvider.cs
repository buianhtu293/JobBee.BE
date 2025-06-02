using JobBee.Domain.Entities;

namespace JobBee.Application.Abstractions
{
	public interface IJwtProvider
	{
		string Generate(User user);
	}
}
