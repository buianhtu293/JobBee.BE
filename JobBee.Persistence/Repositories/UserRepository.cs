using System;
using System.Collections.Generic;
using System.Linq;
using JobBee.Api.Models;
using JobBee.Application.Contracts.Persistence;
using JobBee.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	public class UserRepository : GenericRepository<User, Guid>, IUserRepository
	{
		private readonly JobBeeContext _context;

		public UserRepository(JobBeeContext context) : base(context)
		{
			this._context = context;
		}

		public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
		{
			return await _context
			.Set<User>()
			.FirstOrDefaultAsync(member => member.Email == email, cancellationToken);
		}

		public async Task<bool> IsEmailUniqueAsync(
		string email,
		CancellationToken cancellationToken = default) =>
		!await _context
			.Set<User>()
			.AnyAsync(member => member.Email == email, cancellationToken);
	}
}
