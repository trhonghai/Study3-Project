using Microsoft.AspNetCore.Identity;
using NET.Data.Providers.Models;
using NET.GenericRepository;

namespace NET.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
