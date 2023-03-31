using Kwetter_User.Interfaces;
using Kwetter_User.Models;

namespace Kwetter_User.DAL
{
    public class UserDAL : IUser
    {
        public User AddExperience(int courseId, int userId, int courseToughness)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            User user1 = new User();
            return user1;
        }

        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User Register(User registerData)
        {
            throw new NotImplementedException();
        }

        public void SaveUser()
        {
            throw new NotImplementedException();
        }
    }
}
