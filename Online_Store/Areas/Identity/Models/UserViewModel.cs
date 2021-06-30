using System;
using Online_Store.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Online_Store.Areas.Identity.Models
{
    public class UserViewModel : BaseEntityViewModel<Guid>
    {
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
       
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
