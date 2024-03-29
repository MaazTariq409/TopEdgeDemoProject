﻿using System.ComponentModel.DataAnnotations;

namespace TopEdgeDemoProject.Models
{
    public class ScrapData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string baseUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
