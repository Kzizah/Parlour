using System.ComponentModel.DataAnnotations;

namespace registrationform.Data
{
    public class Customers
    {
       
            [Key]
           
            public string? name { get; set; }
            public string? email { get; set; }

            

        }
    }

