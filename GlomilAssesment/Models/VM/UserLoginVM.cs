using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlomilAssesment.Models.VM
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "E-Mail alanı boş geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        public string Password { get; set; }
    }
}
