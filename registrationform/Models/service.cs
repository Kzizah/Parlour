using System.ComponentModel.DataAnnotations;

namespace registrationform.Models
{
    public class Service
    {
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string  name { get; set; }

        public string description { get; set; }
        
        
        public string price { get; set; }


    }
      
}
