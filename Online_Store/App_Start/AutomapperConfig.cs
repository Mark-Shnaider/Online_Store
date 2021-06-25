using AutoMapper;
using Common.Models.DTO;
using Common.Models.Entities;
using Online_Store.Models;
using Online_Store.Areas.Products.Models;
using Common.Models.Entities.Identity;
using Online_Store.Areas.Identity.Models;

namespace Online_Store.App_Start
{
    public class AutomapperConfig
    {
    }
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateDataMappings();
            CreateBllMappings();
            CreateViewMappings();
        }

        public void CreateBllMappings()
        {
            CreateMap<Amount, AmountDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }

        public void CreateViewMappings()
        {
            CreateMap<AmountDto, AmountViewModel>().ReverseMap();
            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CustomerDto, CustomerViewModel>().ReverseMap();
            CreateMap<OrderDto, OrderViewModel>().ReverseMap();
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
        }

        public void CreateDataMappings()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}
