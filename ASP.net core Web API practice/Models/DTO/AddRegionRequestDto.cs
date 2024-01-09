﻿using System.ComponentModel.DataAnnotations;

namespace Walk_and_Trails_of_SA_API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code has to be  a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be  a maxmimum of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name  has to be  a maximum of  100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
