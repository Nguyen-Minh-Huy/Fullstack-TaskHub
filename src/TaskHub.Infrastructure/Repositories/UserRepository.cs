using Microsoft.EntityFrameworkCore;
using TaskHub.Domain.Entities;
using TaskHub.Domain.Interfaces;
using TaskHub.Infrastructure.Data;

namespace TaskHub.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> IsEmailExistsAsync(string email)
    {
        return await _dbSet
            .AnyAsync(u => u.Email == email);
    }
}