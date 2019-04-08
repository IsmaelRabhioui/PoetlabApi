using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Data
{
    public class PoemDataInitializer
    {
        private readonly PoemDbContext _dbContext;

        public PoemDataInitializer(PoemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                              
            }
        }
    }
}
