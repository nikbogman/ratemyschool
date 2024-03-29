﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Core.Models.Schools
{
    public class LanguageSchoolModel : SchoolModel
    {
        [Required(ErrorMessage = "Primary language property is required")]
        public string PrimaryLanguage { get; set; }

        [Required(ErrorMessage = "Secondary language property is required")]
        public string SecondaryLanguage { get; set; }

        [DefaultValue(null)]
        public int? ScoreRequirement { get; set; }
    }
}
