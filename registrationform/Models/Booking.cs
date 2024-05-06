namespace registrationform.Models
{
    public class Booking
    {
        public string Email { get; set; } 
        public string id { get; set; } = Guid.NewGuid().ToString();
       
        public string service { get; set; }

       
       
        
    }
}
