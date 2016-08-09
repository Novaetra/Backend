using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Novaetra.Backend.Users.Dto
{
    public class GetUserOutput
    {
        public List<UserDto> Users { get; set; }
    }
}
