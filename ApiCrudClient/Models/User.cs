using System.ComponentModel.DataAnnotations;

namespace ApiCrudClient.Models
{
    public class User
    {
        public int ID { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
    }
}
