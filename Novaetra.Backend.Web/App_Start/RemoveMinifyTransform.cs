using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Novaetra.Backend.Web
{
    public class RemoveMinifyTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Files = response.Files.Select(f =>
            {
                f.IncludedVirtualPath = f.IncludedVirtualPath.Replace(".min", "");
                return f;
            }).ToList();
        }
    }
}