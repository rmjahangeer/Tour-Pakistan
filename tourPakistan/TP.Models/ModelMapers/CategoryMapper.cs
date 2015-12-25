using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.WebModels;

namespace Models.ModelMappers
{
    public static class CategoryMapper
    {
        public static CategoryWebModel MapFromServerToClient(this Category source)
        {
            return new CategoryWebModel
            {
                CategoryId = source.CategoryId,
                CategoryName = source.CategoryName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }

        public static Category MapFromClinetToServer(this CategoryWebModel source)
        {
            return new Category
            {
                CategoryId = source.CategoryId,
                CategoryName = source.CategoryName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdate = source.RecLastUpdate,
                RecUpdatedBy = source.RecUpdatedBy
            };
        }
    }
}
