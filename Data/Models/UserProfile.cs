using System.ComponentModel.DataAnnotations;

namespace ShoppiAPIDOTNET.Data.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
