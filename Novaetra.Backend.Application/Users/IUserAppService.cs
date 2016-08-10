using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Novaetra.Backend.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novaetra.Backend.Users
{
    public interface IUserAppService : IApplicationService
    {
        ListResultOutput<UserDto> GetUsers();
    }
}
