using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
    public interface IAspNetUserService
    {
        AspNetUser FindById(string id);
        IEnumerable<AspNetUser> GetAllUsers();
        bool UpdateUser(AspNetUser user);
    }
}
