using System.ComponentModel.DataAnnotations;

namespace ShoppiAPIDOTNET.Data.Models
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(400)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}
        public int UserTypeId { get; set; }
        public int UserStatus { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public UserType UserType { get; set; }

    }
}
