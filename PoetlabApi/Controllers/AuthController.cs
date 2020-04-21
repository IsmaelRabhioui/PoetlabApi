using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PoetlabApi.DTOs;
using PoetlabApi.Models;

namespace PoetlabApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;
        private readonly ApplicationSettings _appSettings;

        public AuthController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        // POST: api/Auth/Register
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="model">the new user/returns>
        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostUserModel(UserModelDTO model)
        {

            var userModel = new UserModel()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(userModel, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        // POST: api/Auth/Login
        /// <summary>
        /// Logs user in
        /// </summary>
        /// <param name="model">the logged in user/returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Jwt_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
           
        }
    }
}