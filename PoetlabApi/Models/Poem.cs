using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Models
{
    public class Poem
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string PoemText { get; set; }

        public string[] Themes { get; set; }

        public IList<String> UpVoters { get; set; }

        public IList<String> DownVoters { get; set; }

        public DateTime Date { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public string Image { get; set; }
        #endregion

        #region Constructors
        public Poem()
        {
            Upvotes = 0;
            Downvotes = 0;
            Date = DateTime.Now;
        }
        #endregion

        #region Methods
        public void AddUpvote() => Upvotes++;

        public void RemoveUpvote() => Upvotes--;

        public void AddDownvote() => Downvotes++;

        public void RemoveDownvote() => Downvotes--;
        #endregion
    }
}
