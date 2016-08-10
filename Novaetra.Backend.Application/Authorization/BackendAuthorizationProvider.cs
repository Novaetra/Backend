using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novaetra.Backend.Authorization
{
    public class BackendAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // TODO: Localize (Change FixedLocalizableString to LocalizableString)

            context.CreatePermission("CanCreateQuestions", new FixedLocalizableString("Can create questions"));
            context.CreatePermission("CanDeleteQuestions", new FixedLocalizableString("Can delete questions"));
            context.CreatePermission("CanDeleteAnswers", new FixedLocalizableString("Can delete answers"));
            context.CreatePermission("CanAnswerToQuestions", new FixedLocalizableString("Can answer to questions"), isGrantedByDefault: true);
        }
    }
}
