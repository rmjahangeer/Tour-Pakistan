using System;
using System.Collections.Generic;
using TP.Models.DomainModels;

namespace TP.Interfaces.IServices
{
     public interface  IUsersService  : IDisposable
     {

         IEnumerable<AspNetUser> GetAllUsers();
     }
}
