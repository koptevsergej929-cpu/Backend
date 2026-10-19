using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Infrastructure.Data;
using TestingPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace TestingPlatform.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext appDbContext, IMapper mapper) : IUserRepository
    {
        public async Task<List<User>> GetAllAsync()
        {
            return await appDbContext.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await appDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new Exception("Пользователь не найден.");

            return user;
        }

        public async Task<int> CreateAsync(User user)
        {
            await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task UpdateAsync(User user)
        {
            appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new Exception("Пользователь не найден.");

            appDbContext.Users.Remove(user);
            await appDbContext.SaveChangesAsync();
        }
    }
}
