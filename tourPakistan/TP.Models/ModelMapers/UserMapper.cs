using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class UserMapper
    {
        public static void UpdateUserTo(this AspNetUser target, AspNetUserModel source)
        {
            target.Address = source.Address;
            target.Telephone = source.Telephone;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.LockoutEnabled = source.LockoutEnabled;


        }
    }
}