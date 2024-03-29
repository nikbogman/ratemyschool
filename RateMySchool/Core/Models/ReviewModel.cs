﻿using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class ReviewModel : IModel
    {
        [Required(ErrorMessage = "Content of review shoud be provided for creation")]
        [MinLength(10)]
        public string Content { get; set; }

        [Required(ErrorMessage = "Rating of review shoud be provided for creation")]
        [Range(1, 5)]
        public int Rating { get; set; }

        public Guid SchoolId { get; set; }
        public Guid UserId { get; set; }
    }
}
