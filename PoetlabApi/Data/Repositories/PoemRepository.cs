using Microsoft.EntityFrameworkCore;
using PoetlabApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Data.Repositories
{
    public class PoemRepository : IPoemRepository
    {
        private PoemDbContext _context;
        private readonly DbSet<Poem> _poems;

        public PoemRepository(PoemDbContext context)
        {
            _context = context;
            _poems = context.Poems;
        }
        public IEnumerable<Poem> GetAll()
        {
            return _poems.ToList();
        }

        public IEnumerable<Poem> GetBy(string author, string theme)
        {
            var poems = _poems.AsQueryable();
            if (!string.IsNullOrEmpty(author))
                poems = poems.Where(p => p.Author.Equals(author, System.StringComparison.OrdinalIgnoreCase));
            if (theme != null)
                poems = poems.Where(p => p.Themes.Contains(theme, StringComparer.OrdinalIgnoreCase));
            return poems.OrderBy(p => p.Author).ToList();
        }

        public Poem GetById(int id)
        {
            return _poems.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Poem poem)
        {
            _poems.Add(poem);
        }

        public void Delete(Poem poem)
        {
            _poems.Remove(poem);
        }

        public void Update(Poem poem)
        {
            _context.Update(poem);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void RenameAuthorPoems(string oldAuthor, string newAuthor)
        {
           _context.Poems.Where(p => p.Author == oldAuthor).ToList().ForEach(p => p.Author = newAuthor);
            SaveChanges();
        }
    }
}
