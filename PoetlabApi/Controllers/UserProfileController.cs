using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PoetlabApi.DTOs;
using PoetlabApi.Models;

namespace PoetlabApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<UserModel> _userManager { get; set; }
        private IPoemRepository _poemRepository { get; set; }

        public UserProfileController(UserManager<UserModel> userManager, IPoemRepository poemRepository)
        {
            _userManager = userManager;
            _poemRepository = poemRepository;
        }

        // GET: api/UserProfile 
        /// <summary>
        /// Gets user personnal information
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }

        // POST: api/UserProfile
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="model">the new user/returns>
        [HttpPost]
        public async Task<Object> PostUserModel(UserModelDTO model)
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            user.Email = model.Email;
            var oldUsername = user.UserName;
            user.UserName = model.UserName;
            if (user.UserName != oldUsername)
            {
                _poemRepository.RenameAuthorPoems(oldUsername, user.UserName);
            }

            try
            {
                var result = await _userManager.UpdateAsync(user);
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                result = await _userManager.ResetPasswordAsync(user, code, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}