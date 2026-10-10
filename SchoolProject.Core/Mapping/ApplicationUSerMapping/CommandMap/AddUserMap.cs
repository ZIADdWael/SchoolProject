using SchoolProject.Core.Features.ApplicationUser.Command.Model;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Core.Mapping.ApplicationUSerMapping
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMap()
        {


            CreateMap<AddUserCommand, User>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Country));



        }
    }
}
