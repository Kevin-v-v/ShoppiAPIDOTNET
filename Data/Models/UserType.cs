using System.ComponentModel.DataAnnotations;

namespace ShoppiAPIDOTNET.Data.Models
{
    public class UserType
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
