using System.ComponentModel.DataAnnotations;

namespace RealEstate.API.Persistence
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Suffix { get; set; }

    }
}
