﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTO
{
    public class RealEstateNoteDto
    {
        [Required]
        public int Id { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage = "The text is required")]
        public string Text { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [Required] 
        public int RealEstateId { get; set; }
    }
}
