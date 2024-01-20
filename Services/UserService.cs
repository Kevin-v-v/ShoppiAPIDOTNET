using Microsoft.EntityFrameworkCore;
using ShoppiAPIDOTNET.Data;
using ShoppiAPIDOTNET.Data.Models;

namespace ShoppiAPIDOTNET.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<UserAccount> GetUserByEmail(string email)
        {
            var user = await _context.UserAccounts.Where(x=> x.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> RegisterUser(UserAccount userAccount, UserProfile userProfile)
        {
            var resultProfile = await _context.UserProfiles.AddAsync(userProfile);

            int result = await _context.SaveChangesAsync();

            if (result < 1)
            {
            
                return false;
            }
            userAccount.UserProfileId = resultProfile.Entity.Id;
            var resultAccount = await _context.UserAccounts.AddAsync(userAccount);

            result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                _context.UserProfiles.Remove(resultProfile.Entity);
                await _context.SaveChangesAsync();
                return false;
            }

            return true;
        }
    }
}
