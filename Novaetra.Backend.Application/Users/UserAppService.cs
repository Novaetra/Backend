using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Novaetra.Backend.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novaetra.Backend.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly UserManager _userManager;

        public UserAppService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public ListResultOutput<UserDto> GetUsers()
        {
            return new ListResultOutput<UserDto>
            {
                Items = _userManager.Users.ToList().MapTo<List<UserDto>>()
            };
        }
    }
}
