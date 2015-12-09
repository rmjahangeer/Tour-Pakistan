using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    public class CategoryRepository
    {
        private readonly BaseDbContext entities;
        CategoryRepository()
        {
            entities = new BaseDbContext();
        }

        IEnumerable<Category> GetAll()
        {
            return entities.Categories.Select(x => x).ToList();
        }

        Category GetById(long id)
        {
            return entities.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
        }
    }
}
