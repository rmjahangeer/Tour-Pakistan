using System.Collections.Generic;
using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.WebViewModels
{
    public class AspNetUsersViewModel
    {
        public AspNetUserModel AspNetUserModel { get; set; }
        public List<AspNetRole> Roles { get; set; }
    }
}