using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteApi.Dtos;
using NewsWebsiteApi.helpers;
using System.Text.Json;

namespace NewsWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenServices _tokenServices;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public NewsController(IUnitOfWork unitOfWork,ITokenServices tokenServices,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _tokenServices = tokenServices;
           _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(NewsDto newsDto)
        {
        // newsDto.Image=   DocumentSeting.UploadFile(newsDto.imagepath, "Images");
            var news = new News()
            {
                Title = newsDto.Title,
                NewsBody = newsDto.NewsBody,
                Image = newsDto.Image,
                PublicationDate = newsDto.PublicationDate,
            //    CreationDate = newsDto.CreationDate,
                AuthorId = newsDto.AuthorId

            };

            await _unitOfWork.NewsRepository.Add(news);
            await _unitOfWork.CompleteAsync();
            return Ok(news);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<News>>> GetAll()
        {

            var result = await _unitOfWork.NewsRepository.GetAllAsync();
            var mappedNews = _mapper.Map<IReadOnlyList<News>, IReadOnlyList<newstoReturnDto>>(result);
            return Ok(mappedNews);

        }
        [HttpGet("id")]
        public async Task<ActionResult<IReadOnlyList<News>>> GetById(int id)
        {

            var result = await _unitOfWork.NewsRepository.GetByIdAsync(id);
            var mappedNews = _mapper.Map<News,newstoReturnDto>(result);
            return Ok(mappedNews);

        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<ActionResult<IReadOnlyList<News>>> UpdateNews(int id,NewsDto news)
        {
            var result = await _unitOfWork.NewsRepository.GetByIdAsync(id);
            if (result != null)
            {
                result.Title = news.Title;
                result.NewsBody = news.NewsBody;
                result.CreationDate = news.CreationDate;
                result.PublicationDate = news.PublicationDate;
                //  result.Author = news.Author;
                result.AuthorId = news.AuthorId;
                result.Image = news.Image;

              await  _unitOfWork.CompleteAsync();
                return Ok(result);
                   
            }
            return BadRequest();
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<IReadOnlyList<News>>> DeleteNews(int id)
        {
            var result = await _unitOfWork.NewsRepository.GetByIdAsync(id);
            if (result != null)
            {
                _unitOfWork.NewsRepository.Delete(result);
                await _unitOfWork.CompleteAsync();
                return Ok(result);

            }
            return BadRequest();
        }



        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LogInDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized();
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenServices.CreateTokenAsync(user, _userManager)
            });

        }
    }
}
