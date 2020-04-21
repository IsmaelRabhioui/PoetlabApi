using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Models
{
    public class ApplicationSettings
    {
        public string Jwt_Secret { get; set; }
        public string Client_Url { get; set; }
    }
}
