using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IRepository
{
    public interface IUsersRepository : IBaseRepository<AspNetUser,int>
    {
        IEnumerable<AspNetUser> GetAllUsers();
    }
}
