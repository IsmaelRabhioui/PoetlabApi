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
    public class PoemsController : ControllerBase
    {
        private readonly IPoemRepository _poemRepository;

        public PoemsController(IPoemRepository context)
        {
            _poemRepository = context;
        }

        // GET: api/Poems
        /// <summary>
        /// Get all poems
        /// </summary>
        /// <returns>array of poems</returns>
        [HttpGet]
        public IEnumerable<Poem> GetPoems(string author = null, string theme = null)
        {
            if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(theme))
                return _poemRepository.GetAll();
            return _poemRepository.GetBy(author, theme);
        }

        // GET: api/Poems/1
        /// <summary>
        /// Get all poems with the given id
        /// </summary>
        /// <returns>A poem</returns>
        [HttpGet("{id}")]
        public ActionResult<Poem> GetPoem(int id)
        {
            Poem poem = _poemRepository.GetById(id);
            return poem;
        }

        // POST: api/Poems
        /// <summary>
        /// Adds a new poem
        /// </summary>
        /// <param name="poemDTO">the new poem</returns>
        [HttpPost]
        public ActionResult<Poem> PostPoem(PoemDTO poemDTO)
        {
            Poem poem = new Poem {
                Title = poemDTO.Title,
                Author = poemDTO.Author,
                PoemText = poemDTO.PoemText,
                Themes = poemDTO.Themes,
                UpVoters = new List<string>(),
                DownVoters = new List<string>(),
                Image = poemDTO.Image };
            _poemRepository.Add(poem);
            _poemRepository.SaveChanges();

            return NoContent();
        }

        // PUT: api/Poem/1
        /// <summary>
        /// Modifies a poem
        /// </summary>
        /// <param name="id">id of the poem to be modified</param>
        /// <param name="poem">the modified poem</param>
        [HttpPut("{id}")]
        public IActionResult PutPoem(int id, Poem poem)
        {
            if (id != poem.Id)
            {
                return BadRequest();
            }
            _poemRepository.Update(poem);
            _poemRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Poems/1
        /// <summary>
        /// Deletes a poem
        /// </summary>
        /// <param name="id">the id of the poem to be deleted</param>
        [HttpDelete("{id}")]
        public ActionResult<Poem> DeletePoem(int id)
        {
            Poem poem = _poemRepository.GetById(id);

            _poemRepository.Delete(poem);
            _poemRepository.SaveChanges();
            return poem;
        }
    }
}