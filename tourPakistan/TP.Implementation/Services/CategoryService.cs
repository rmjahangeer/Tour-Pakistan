using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TP.Interfaces.IRepository;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
    public class CategoryService:ICateogryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public bool AddUpdateCategory(Category category)
        {
            if (category.CategoryId == 0)
            {
                categoryRepository.Add(category);
            }
            else
            {
                categoryRepository.Update(category);
            }
            categoryRepository.SaveChanges();
            return true;
        }

        public Category GetCategoryById(long id)
        {
            return categoryRepository.Find(id);
        }

        public bool DeleteCategory(long id)
        {
            var toDetele = categoryRepository.Find(id);
            categoryRepository.Delete(toDetele);
            categoryRepository.SaveChanges();
            return true;

        }

    }
}
