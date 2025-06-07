using JobBee.Domain.Entities;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IUserRepository : IGenericRepository<User, Guid>
	{
		Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

		Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);

		Task<User> Login(string email, string password);
	}
}
