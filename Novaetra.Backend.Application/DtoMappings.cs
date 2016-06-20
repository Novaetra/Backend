using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Novaetra.Backend.Entities;
using Novaetra.Backend.Users.Dto;

namespace Novaetra.Backend
{
    internal static class DtoMappings
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
        }
    }
}
