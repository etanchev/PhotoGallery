using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public class EmailModelBlazor
    {
        [Required(ErrorMessage = "Моля въведете Име")]
        [RegularExpression(@"^[\p{L} ]*$", ErrorMessage = "Името съдържа цифри!")] //\p{L} is used for unicode chars
        public string Name { get; set; }

        
        [Required(ErrorMessage = "Моля въведете Телефон")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Телефона съдържа букви!")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Моля въведете Имейл")]
        [EmailAddress(ErrorMessage = "Грешен Имейл")]
        public string Email { get; set; }

        public List<string> Body { get; set; }
    }
}
