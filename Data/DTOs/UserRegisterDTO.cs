using System.ComponentModel.DataAnnotations;

namespace ShoppiAPIDOTNET.Data.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        [EmailAddress]
        [MaxLength(400)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        public int UserTypeId { get; set; }
    }
}
