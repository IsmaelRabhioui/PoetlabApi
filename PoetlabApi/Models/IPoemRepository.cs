using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Models
{
    public interface IPoemRepository
    {
        IEnumerable<Poem> GetAll();
        IEnumerable<Poem> GetBy(string author, string theme);
        Poem GetById(int id);
        void Add(Poem poem);
        void Delete(Poem poem);
        void Update(Poem poem);
        void SaveChanges();
        void RenameAuthorPoems(string oldAuthor, string newAuthor);
    }
}
