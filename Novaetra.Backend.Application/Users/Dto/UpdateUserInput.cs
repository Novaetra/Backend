using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Novaetra.Backend.Users.Dto
{
    public class UpdateUserInput : UserBaseDto
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
