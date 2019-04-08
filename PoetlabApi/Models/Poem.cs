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

        public string Theme { get; set; }

        public DateTime Date { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public string Image { get; set; }
        #endregion

        #region Constructors
        public Poem(string title, string author, string poemText, string theme = "No Theme", string image = "No Image")
        {
            Title = title;
            Author = author;
            PoemText = poemText;
            Theme = theme;
            Image = image;
            Upvotes = 0;
            Downvotes = 0;
            Date = DateTime.Now;
        }
        #endregion

        #region Methods
        public void AddUpvote() => Upvotes++;

        public void RemoveUpvote() => Upvotes--;

        public void AddDownvote() => Downvotes++;

        public void RemoveDownvote() => Downvotes++;
        #endregion
    }
}
