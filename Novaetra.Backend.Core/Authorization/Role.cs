using Abp.Authorization.Roles;
using Novaetra.Backend.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novaetra.Backend.Authorization
{
    public class Role : AbpRole<User>
    {
        public Role()
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}
