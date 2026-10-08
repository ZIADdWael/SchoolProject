using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Command.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Command.Handler
{
    public class UserCommandHandler : ResponseHandler
        , IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //if email is exist
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
            }

            var userByName = await _userManager.FindByNameAsync(request.UserName);
            if (userByName != null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
            }
            // mapping

            var UserAfterMap = _mapper.Map<User>(request);
            var createResult = await _userManager.CreateAsync(UserAfterMap, request.Password);

            if (!createResult.Succeeded)
            {
                return BadRequest<string>(createResult.Errors.FirstOrDefault().Description);

            }

            return Created("");


        }
    }
}
