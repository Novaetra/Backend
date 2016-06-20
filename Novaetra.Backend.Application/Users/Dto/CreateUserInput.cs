using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Novaetra.Backend.Users.Dto
{
    public class CreateUserInput : UserBaseDto, IInputDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public override string Password { set { base.Password = value; } }
    }
}
