//using TP.Models.DomainModels;

//namespace TP.Models.ModelMapers
//{
//    public static class AreaMapper
//    {
//        public static AreaWebModel MapFromServerToClient(this Area source)
//        {
//            return new AreaWebModel
//            {
//                ProvinceId = source.ProvinceId,
//                AreaId = source.AreaId,
//                AreaName = source.AreaName,
//                AreaDescription = source.AreaDescription,
//                RecCreatedBy = source.RecCreatedBy,
//                RecCreatedDate = source.RecCreatedDate,
//                RecLastUpdate = source.RecLastUpdate,
//                RecUpdatedBy = source.RecUpdatedBy
//            };
//        }

//        public static Area MapFromClientToServer(this AreaWebModel source)
//        {
//            return new Area
//            {
//                ProvinceId = source.ProvinceId,
//                AreaId = source.AreaId,
//                AreaName = source.AreaName,
//                AreaDescription = source.AreaDescription,
//                RecCreatedBy = source.RecCreatedBy,
//                RecCreatedDate = source.RecCreatedDate,
//                RecLastUpdate = source.RecLastUpdate,
//                RecUpdatedBy = source.RecUpdatedBy
//            };
//        }
//    }
//}
