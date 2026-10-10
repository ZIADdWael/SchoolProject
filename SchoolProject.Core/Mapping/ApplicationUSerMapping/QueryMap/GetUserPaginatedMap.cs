using SchoolProject.Core.Features.ApplicationUser.Query.Result;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.ApplicationUSerMapping
{
    public partial class ApplicationUserProfile
    {
        public void GetUserPaginatedMap() {

            CreateMap<User, GetUserPaginatedListResponse>();
        
        }
    }
}
