using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novaetra.Backend.Entities;

namespace Novaetra.Backend.EntityFramework
{
    internal class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(u => u.Email).IsRequired().HasMaxLength(512);
            Property(u => u.DisplayName).IsRequired().HasMaxLength(64).HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));
        }
    }
}
