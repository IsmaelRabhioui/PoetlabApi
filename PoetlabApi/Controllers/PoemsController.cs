using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoetlabApi.DTOs;
using PoetlabApi.Models;

namespace PoetlabApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PoemsController : ControllerBase
    {
        private readonly IPoemRepository _poemRepository;

        public PoemsController(IPoemRepository context)
        {
            _poemRepository = context;
        }

        [HttpGet]
        public IEnumerable<Poem> GetPoems(string author = null, string theme = "No Theme")
        {
            if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(theme))
                return _poemRepository.GetAll();
            return _poemRepository.GetBy(author, theme);
        }

        [HttpGet("{id}")]
        public ActionResult<Poem> GetPoem(int id)
        {
            Poem poem = _poemRepository.GetById(id);
            return poem;
        }

        [HttpPost]
        public ActionResult<Poem> PostPoem(PoemDTO poemDTO)
        {
            Poem poem = new Poem(poemDTO.Title, poemDTO.Author, poemDTO.PoemText , poemDTO.Theme, poemDTO.Image);
            _poemRepository.Add(poem);
            _poemRepository.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutPoem(int id, Poem poem)
        {
            _poemRepository.Update(poem);
            _poemRepository.SaveChanges();
            return NoContent();
        }

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