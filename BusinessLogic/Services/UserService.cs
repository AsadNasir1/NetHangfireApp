using Microsoft.EntityFrameworkCore;
using NetHangfireDB;
using NetHangfireDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IUserService
    {
        Task<User> GetById(long id);
        Task<List<User>> GetAllUsers();
        Task AddUser(User newUser);
    }
    public class UserService : IUserService
    {
        private readonly NetHangfireDBContext _dbContext;

        public UserService(NetHangfireDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task AddUser(User newUser)
        {
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetById(long id)
        {
            return await _dbContext.Users.Where(x => x.UserID == id).FirstOrDefaultAsync();
        }

    }
}
