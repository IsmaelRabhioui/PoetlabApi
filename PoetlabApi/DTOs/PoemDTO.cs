using PoetlabApi.Models;
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
        [Required]
        public string[] Themes { get; set; }
        public IList<String> UpVoters { get; set; }
        public IList<String> DownVoters { get; set; }
        public DateTime? Date { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public string Image { get; set; }

    }
}
