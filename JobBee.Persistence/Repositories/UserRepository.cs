using JobBee.Domain.Entities;
using JobBee.Application.Contracts.Persistence;
using JobBee.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	public class UserRepository : GenericRepository<User, Guid>, IUserRepository
	{
		private readonly JobBeeContext _context;
		private readonly IPasswordHasher _passwordHasher;

		public UserRepository(JobBeeContext context,
			IPasswordHasher passwordHasher) : base(context)
		{
			this._context = context;
			this._passwordHasher = passwordHasher;
		}

		public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
		{
			return await _context
			.Set<User>()
			.FirstOrDefaultAsync(member => member.Email == email, cancellationToken);
		}

		public async Task<List<User>> GetUserOpenToWork()
		{
			var users = await _context.users
				.Include(u => u.Candidate)
				.Where(u => u.Candidate != null && u.Candidate.IsAvailableForHire == true)
				.ToListAsync();

			if (users == null || users.Count == 0)
				throw new KeyNotFoundException("No users are currently open to work.");

			return users;
		}

		public async Task<User> InsertUserAsync(User user)
		{
			var entry = await _context.Set<User>().AddAsync(user);
			return entry.Entity;
		}

		public async Task<bool> IsEmailUniqueAsync(
		string email,
		CancellationToken cancellationToken = default) =>
		!await _context
			.Set<User>()
			.AnyAsync(member => member.Email == email, cancellationToken);

		public async Task<User> Login(string email, string password)
		{
			User? user = await GetByEmailAsync(email);

			if (user is null)
			{
				throw new Exception("The user was not found");
			}

			bool verified = _passwordHasher.Verify(password, user.PasswordHash);

			if (!verified)
			{
				user = null;
			}

			return user;
		}
	}
}
