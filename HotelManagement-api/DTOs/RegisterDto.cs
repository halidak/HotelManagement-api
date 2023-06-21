using System.ComponentModel.DataAnnotations;

namespace HotelManagement_api.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
