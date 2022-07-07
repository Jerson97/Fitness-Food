using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (User == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new CodeErrorResponse(401));
            }
            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Token = "este es tu token",
                Name = user.Name,
                Lastname = user.lastname
            };
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UserDto>> Registrar(RegisterDto registrarDto)
        {
            var user = new User
            {
                Email = registrarDto.Email,
                UserName = registrarDto.Username,
                Name = registrarDto.Name,
                lastname = registrarDto.Lastname
            };
            var resultado = await _userManager.CreateAsync(user, registrarDto.Password);

            if (!resultado.Succeeded)
            {
                return BadRequest(new CodeErrorResponse(400));
            }

            return new UserDto
            {
                Name = user.Name,
                Lastname = user.lastname,
                Token = "este es tu token",
                Email = user.Email,
                Username = user.UserName
            };
        }
    }
}
