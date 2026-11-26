using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories;

namespace Services
{
    public class UsersService : IUserService
    {
        
        private readonly IUsersRepository repository;
        private readonly IConfiguration configuration;
        public UsersService(IUsersRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);
        }
        public async Task<User> AddUser(User user)
        {
            if (ValidatePassword(user.Password) >= this.configuration.GetValue<int>("PasswordStrengthRequired",3))
                return await repository.AddUser(user);
            return null;
        }

        public async Task<User> Login(UserLogIn loginUser)
        {
            User user = await repository.GetUserByEmailAndPassword(loginUser);
            if (user == null)
                return null;
            return user;
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            if (ValidatePassword(user.Password) < 3)
                return null;
            return await repository.UpdateUser(id, user);
        }

        public int ValidatePassword(string password)
        {
            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }
    }
}