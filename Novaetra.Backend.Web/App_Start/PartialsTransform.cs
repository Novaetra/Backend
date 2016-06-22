using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace Novaetra.Backend.Web
{
    public class PartialsTransform : IBundleTransform
    {
        private readonly string _moduleName;
        public PartialsTransform(string moduleName)
        {
            _moduleName = moduleName;
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            var strBundleResponse = new StringBuilder();
            // Javascript module for Angular that uses templateCache 
            strBundleResponse.AppendFormat(@"angular.module('{0}').run(['$templateCache',function(t){{", _moduleName);

            foreach (var file in response.Files)
            {
                // Get the partial page, remove line feeds and escape quotes
                var stream = file.VirtualFile.Open();
                string content;
                using (var sr = new StreamReader(stream))
                    content = sr.ReadToEnd();
                // Create insert statement with template
                strBundleResponse.AppendFormat(@"t.put('partials/{0}','{1}');", file.VirtualFile.Name, content.Replace("\r\n", "").Replace("'", "\\'"));
            }
            strBundleResponse.Append(@"}]);");

            response.Files = new BundleFile[] { };
            response.Content = strBundleResponse.ToString();
            response.ContentType = "text/javascript";
        }
    }
}