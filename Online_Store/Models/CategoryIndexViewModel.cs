using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Online_Store.Models.Base;


namespace Online_Store.Models
{
    public class CategoryIndexViewModel : BaseEntityViewModel<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
