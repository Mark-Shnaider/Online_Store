using System.ComponentModel.DataAnnotations;

namespace Online_Store.Areas.Identity.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Имя пользователя")]
        public string UserName { get; set; }
        [Display(Name ="Пароль")]
        public string Password { get; set; }
        [Display(Name ="Запомнить пользователя")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
