using AutoMapper;
using Common.Models.DTO;
using Common.Models.Entities;
using Online_Store.Models;

namespace Online_Store.App_Start
{
    public class AutomapperConfig
    {
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateBllMappings();
            CreateViewMappings();
        }

        public void CreateBllMappings()
        {
            

        }

        public void CreateViewMappings()
        {
            
        }
    }
}
