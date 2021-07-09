using AutoMapper;
using Common.Models.DTO;
using Common.Models.Entities;
using Online_Store.Models;
using Common.Models.Entities.Identity;
using Online_Store.Areas.Identity.Models;
using Online_Store.Areas.Admin.Models;


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
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
        }

        public void CreateViewMappings()
        {
            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryDto, CategoryIndexViewModel>().ReverseMap();
            CreateMap<OrderDto, OrderViewModel>().ReverseMap();
            CreateMap<ShoppingCartDto, ShoppingCartViewModel>().ReverseMap();
            CreateMap<ShoppingCartItemDto, ShoppingCartItemViewModel>().ReverseMap();

            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            CreateMap<ProductDto, ProductCustomerViewModel>().ReverseMap();
        }

        public void CreateDataMappings()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<LoginViewModel, User>().ReverseMap();
        }
    }
}
