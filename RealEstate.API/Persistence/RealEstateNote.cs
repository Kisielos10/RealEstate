using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Persistence
{
    public class RealEstateNote
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage = "The text is required")]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required] 
        public int RealEstateId { get; set; }
    }
}
