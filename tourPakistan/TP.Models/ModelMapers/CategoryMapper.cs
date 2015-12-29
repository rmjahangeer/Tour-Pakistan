using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace Models.ModelMappers
{
    public static class CategoryMapper
    {
        public static CategoryModel MapFromServerToClient(this Category source)
        {
            return new CategoryModel
            {
                CategoryId = source.CategoryId,
                CategoryName = source.CategoryName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                IsActive = source.IsActive
            };
        }

        public static Category MapFromClinetToServer(this CategoryModel source)
        {
            return new Category
            {
                CategoryId = source.CategoryId,
                CategoryName = source.CategoryName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                IsActive = source.IsActive
            };
        }
    }
}
