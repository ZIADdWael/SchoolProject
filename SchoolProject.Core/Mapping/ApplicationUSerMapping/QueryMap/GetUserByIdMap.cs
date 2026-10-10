using SchoolProject.Core.Features.ApplicationUser.Query.Result;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Core.Mapping.ApplicationUSerMapping
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMap()
        {
            CreateMap<User, GetUserByIdResponse>();

        }
    }
}
