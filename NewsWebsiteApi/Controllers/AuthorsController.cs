using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsWebsiteApi.Dtos;

namespace NewsWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Author>>> GetAll()
        {

            var result = await _unitOfWork.AuthorRepository.GetAllAsync();
           
            return Ok(result);

        }
        [HttpGet("id")]
        public async Task<ActionResult<IReadOnlyList<Author>>> GetById(int id)
        {

            var result = await _unitOfWork.AuthorRepository.GetByIdAsync(id);
           
            return Ok(result);

        }

    }
}
