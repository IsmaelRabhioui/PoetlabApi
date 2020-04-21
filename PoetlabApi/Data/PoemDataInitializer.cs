using Microsoft.AspNetCore.Identity;
using PoetlabApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Data
{
    public class PoemDataInitializer
    {
        private readonly PoemDbContext _dbContext;
        private readonly UserManager<UserModel> _userManager;

        public PoemDataInitializer(PoemDbContext dbContext, UserManager<UserModel> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                var userWeb4 = new UserModel()
                {
                    UserName = "web4",
                    Email = "web4@hogent.be"
                };

                var userIsmael = new UserModel()
                {
                    UserName = "ismael",
                    Email = "ismael@hotmail.com"
                };


                IdentityResult result = _userManager.CreateAsync(userWeb4, "gelukkiggeennetbeans").Result;
                IdentityResult result2 = _userManager.CreateAsync(userIsmael, "test123").Result;

            }
        }
    }
}
