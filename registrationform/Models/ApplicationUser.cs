using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace registrationform.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
    }
}
