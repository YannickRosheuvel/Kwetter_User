using Kwetter_User.Models;

namespace Kwetter_User.Interfaces
{
    public interface IUser
    {
        void SaveUser();
        User GetUser(int id);
        User Login(string email, string password);
        User AddExperience(int courseId, int userId, int courseToughness);
        User Register(User registerData);
    }
}
