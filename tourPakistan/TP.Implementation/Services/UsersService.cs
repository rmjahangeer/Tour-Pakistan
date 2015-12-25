using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;

namespace TMD.Implementation.Services
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
