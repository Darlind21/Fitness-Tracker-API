using Fitness_Tracker_API.DataLayer.Models;

namespace Fitness_Tracker_API.BusinessLayer.Infrastructure
{
    public interface IUserService
    {
        public User CreateUser();
        public void EditUser(int id);
        public void DeleteUser(int id);
        public User GetUserById(int id);
        public List<User> GetAllUsers();
   }
}
