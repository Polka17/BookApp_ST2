using PollyBookApp_ST2.Models.Enums;

namespace PollyBookApp_ST2.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; } 
    }
}
