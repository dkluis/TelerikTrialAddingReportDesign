using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorApp2.Models
{
    public class SettingsModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public List<MyDropDownListModel> Country { get; set; }

        public string Website { get; set; }
    }
}
