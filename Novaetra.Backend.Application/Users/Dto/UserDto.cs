using Abp.AutoMapper;
using Novaetra.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novaetra.Backend.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto
    {
        public string DisplayName { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
