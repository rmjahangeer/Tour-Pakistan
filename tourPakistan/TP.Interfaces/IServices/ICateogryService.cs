using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface ICateogryService
    {
        IEnumerable<Category> GetAllCategories();
        bool AddUpdateCategory(Category category);

        Category GetCategoryById(long id);
    }
}
