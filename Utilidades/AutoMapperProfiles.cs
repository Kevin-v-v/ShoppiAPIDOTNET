using AutoMapper;
using ShoppiAPIDOTNET.Data.DTOs;
using ShoppiAPIDOTNET.Data.Models;

namespace ShoppiAPIDOTNET.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDTO, UserAccount>();
            CreateMap<UserRegisterDTO, UserProfile>();
        }
    }
}
