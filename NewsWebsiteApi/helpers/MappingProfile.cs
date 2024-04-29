using AutoMapper;
using Infrastructure.Entities;
using NewsWebsiteApi.Dtos;

namespace NewsWebsiteApi.helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<News, newstoReturnDto>().ForMember(n => n.Image, o => o.MapFrom<NewsPictureUrlResolver>());
        }
    }
}
