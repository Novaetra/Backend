using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Novaetra.Backend.Entities
{
    public class User : Entity, IHasCreationTime, IHasDeletionTime
    {
        public virtual string DisplayName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsEmailConfirmed { get; set; }


        // Acount
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public virtual int AccountId { get; set; }

        // Auditing
        public virtual DateTime CreationTime { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
    }
}
