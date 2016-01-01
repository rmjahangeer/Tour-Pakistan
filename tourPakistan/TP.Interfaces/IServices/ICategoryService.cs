using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        bool AddUpdateCategory(Category category);

        Category GetCategoryById(long id);
        bool DeleteCategory(long id);
    }
}
