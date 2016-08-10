using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novaetra.Backend.Configuration
{
    public class BackendSettingProvider : SettingProvider
    {
        // public const string ExampleSetting = "SettingName";

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[]
                   {
                       // new SettingDefinition(ExampleSetting, "SETTINGVALUE")
                   };
        }
    }
}
