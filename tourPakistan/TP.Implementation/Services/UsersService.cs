using System.Collections.Generic;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TP.Implementation.Services
{
     public   class UsersService : IUsersService
    {

          #region 'Private and Constructor'
        


        public UsersService()
        {
        }

       #endregion 'Private and Constructor'


        public IEnumerable<AspNetUser> GetAllUsers()
        {
            return null;
        }

        public void Dispose()
        {
            
        }
    }
}
