﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication2.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nuvarande lösenord")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lösenordet måste vara minst 4 och max 100 tecken långt.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt lösenord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ange nya lösenordet igen")]
        [Compare("NewPassword", ErrorMessage = "Det nya lösenordet matchar inte varandra.")]
        public string ConfirmPassword { get; set; }
    }
}
