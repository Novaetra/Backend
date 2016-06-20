using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Novaetra.Backend.Users.Dto;

namespace Novaetra.Backend.Users
{
    public interface IUserService : IApplicationService
    {
        GetUserOutput GetUsers(GetUserInput input);
        void UpdateUser(UpdateUserInput input);
        void CreateUser(CreateUserInput input);
    }
}
