using System.ComponentModel.DataAnnotations;

namespace Kwetter_User.Models
{
    public class User
    {

            [Key]
            public int Id { get; set; }
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Paswword { get; set; }
            public string Email { get; set; }


            public User()
            {
                Username = "Yannick";
            }
        }
    }

