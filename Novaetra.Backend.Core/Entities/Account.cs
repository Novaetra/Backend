using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Novaetra.Backend.Entities
{
    public class Account : Entity, IHasModificationTime
    {
        public virtual byte[] PasswordHash { get; set; }
        public virtual byte[] Salt { get; set; }
        public virtual int IterationCount { get; set; }

        public virtual DateTime? LastModificationTime { get; set; }
    }
}
