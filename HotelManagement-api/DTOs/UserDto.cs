using System.ComponentModel.DataAnnotations;

namespace HotelManagement_api.DTOs
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
