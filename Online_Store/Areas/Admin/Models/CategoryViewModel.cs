using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Online_Store.Models.Base;


namespace Online_Store.Areas.Admin.Models
{
    public class CategoryViewModel : BaseEntityViewModel<Guid>
    {
        [Required]
        [StringLength(25)]
        [Remote(areaName: "Admin", controller: "Category", action: "VerifyName")]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
