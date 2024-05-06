using System.ComponentModel.DataAnnotations;

namespace registrationform.Models
{
    public class ImageModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string servicename { get; set; }
        public byte[] ImageData { get; set; }
    }

}
