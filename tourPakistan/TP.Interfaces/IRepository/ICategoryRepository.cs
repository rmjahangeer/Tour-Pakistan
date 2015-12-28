using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category,long>
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetAllActiveCategories();
    }
}
