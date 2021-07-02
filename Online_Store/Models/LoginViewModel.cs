using System.ComponentModel.DataAnnotations;
using System;
using Online_Store.Models.Base;

namespace Online_Store.Areas.Identity.Models
{
    public class LoginViewModel : BaseEntityViewModel<Guid>
    {
        [Required]
        [Display(Name ="Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомнить пользователя")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
