using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.DTOs
{
    public class PoemDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string PoemText { get; set; }
        
        public string Theme { get; set; }
        public string Image { get; set; }

    }
}
