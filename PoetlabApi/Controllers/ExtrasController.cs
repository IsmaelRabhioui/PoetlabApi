using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoetlabApi.DTOs;
using PoetlabApi.Models;

namespace PoetlabApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ExtrasController : ControllerBase
    {
        private readonly IPoemRepository _poemRepository;

        public ExtrasController(IPoemRepository context)
        {
            _poemRepository = context;
        }

        // PUT: api/vote/
        /// <summary>
        /// Adds up/downvote for a poem
        /// </summary>
        /// <param name="id">id of the poem to be up/downvoted</param>
        /// <param name="author">voter</param>
        /// <param name="vote">Vote 1 = upvote, 0 = downvote</param>
        [HttpPut()]
        public IActionResult PutVote(int id, string author, int vote)
        {
            Poem poem = _poemRepository.GetById(id);
            if (vote == 0)
            {   
                if (!poem.DownVoters.Contains(author))
                {
                    poem.AddDownvote();
                    poem.DownVoters.Add(author);
                    if(poem.UpVoters.Contains(author))
                    {
                        poem.RemoveUpvote();
                        poem.UpVoters.Remove(author);
                    }
                }

            }
            else
            {
                if (!poem.UpVoters.Contains(author))
                {
                    poem.AddUpvote();
                    poem.UpVoters.Add(author);
                    if (poem.DownVoters.Contains(author))
                    {
                        poem.RemoveDownvote();
                        poem.DownVoters.Remove(author);
                    }
                }
            }
            _poemRepository.Update(poem);
            _poemRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/vote/
        /// <summary>
        /// Delete vote
        /// </summary>
        /// <param name="id">id of the poem to delete up/downvoted</param>
        /// <param name="author">voter</param>
        /// <param name="vote">Vote 1 = upvote, 0 = downvote</param>
        [HttpDelete()]
        public IActionResult DeleteVote(int id, string author, int vote)
        {
            Poem poem = _poemRepository.GetById(id);
            if (vote == 0)
            {
                if(poem.DownVoters.Contains(author))
                {
                    poem.RemoveDownvote();
                    poem.DownVoters.Remove(author);
                }
            }
            else
            {
                if (poem.UpVoters.Contains(author))
                {
                    poem.RemoveUpvote();
                    poem.UpVoters.Remove(author);
                }
            }
            _poemRepository.Update(poem);
            _poemRepository.SaveChanges();
            return NoContent();
        }
    }
}