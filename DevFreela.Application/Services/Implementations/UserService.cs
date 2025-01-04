using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(CreateUserInputModel createUserInputModel)
        {
            var user = new User(createUserInputModel.FullName, createUserInputModel.Email, createUserInputModel.BirthDate);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public UserViewModel? GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if(user is null)
                return null;

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
