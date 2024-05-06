using System.ComponentModel.DataAnnotations;

namespace registrationform.Models
{
    public class Customer
    {
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string? name { get; set; }
        public string? email { get; set; }
    }
}
