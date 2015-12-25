using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface IAspNetUserRepository : IBaseRepository<AspNetUser, string>
    {
        IEnumerable<AspNetUser> GetAllUsers();
    }

}
