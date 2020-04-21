using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Models
{
    public class UserModel : IdentityUser
    {
        public IEnumerable<Poem> Poems {get; set; }
    }
}
