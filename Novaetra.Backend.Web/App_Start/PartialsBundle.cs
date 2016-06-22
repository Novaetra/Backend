using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Novaetra.Backend.Web
{
    public class PartialsBundle : Bundle
    {
        public PartialsBundle(string virtualPath, string moduleName)
            : base(virtualPath, new PartialsTransform(moduleName), new JsMinify())
        {
        }
    }
}