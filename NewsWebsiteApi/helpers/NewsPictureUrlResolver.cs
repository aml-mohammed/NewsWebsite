using AutoMapper;
using Infrastructure.Entities;
using NewsWebsiteApi.Dtos;

namespace NewsWebsiteApi.helpers
{
    public class NewsPictureUrlResolver : IValueResolver<News, newstoReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public NewsPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(News source, newstoReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Image))

                return $"{_configuration["ApiBaseUrl"]}{source.Image}";
            return string.Empty;

        }
    }


}
