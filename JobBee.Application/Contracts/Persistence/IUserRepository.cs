using JobBee.Api.Models;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IUserRepository : IGenericRepository<User, Guid>
	{
		Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

		Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);
	}
}
