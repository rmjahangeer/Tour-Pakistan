using System.Linq;
using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class AspNetUserMapper
    {
        public static AspNetUserModel CreateFrom(this AspNetUser source)
        {
             AspNetUserModel oModel = new AspNetUserModel
            {
                Address = source.Address,
                DateOfBirth = source.DateOfBirth,
                Email = source.Email,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Id = source.Id,
                ImageName = source.ImageName,
                Telephone = source.Telephone,
                UserName = source.UserName,
                LockoutEnabled =  source.LockoutEnabled,
                LockoutEnabledString =  source.LockoutEnabled ? "Yes" : "No",
                IsConfirmedString = source.EmailConfirmed ? "Yes" : "No",
                RoleName = source.AspNetRoles.Any() ? source.AspNetRoles.First().Name : "",
                RoleId = source.AspNetRoles.Any() ? source.AspNetRoles.First().Id : ""
            };
            return oModel;

        }

        //public static AspNetUser CreateFrom(this AspNetUserModel source)
        //{
        //    AspNetUserModel oModel = new AspNetUserModel
        //    {

        //        Address = source.Address,
        //        DateOfBirth = source.DateOfBirth,
        //        Email = source.Email,
        //        FirstName = source.FirstName,
        //        LastName = source.LastName,
        //        Id = source.Id,
        //        ImageName = source.ImageName,
        //        Telephone = source.Telephone,
        //        UserName = source.UserName,

        //        RoleName = source..Any() ? source.AspNetRoles.First().Name : ""

        //    };
        //    return oModel;

        //}
    }
}