using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SberTaskDLA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberTaskDLA.Extensions
{
    public static class UserManagerExtenstions
    {
        public static async Task<ApplicationUser> FindByPhoneNumberAsync(this UserManager<ApplicationUser> userManager, string phoneNumber)
        {
            return await userManager?.Users?.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }
    }
}
