using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace QuotesApp2.Shared.Test
{
    public static class TestUtilities
    {
        public static HttpResponseMessage GetHttpResponseMessage(string resource, HttpStatusCode statusCode) =>
            new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(ReadStringFromEmbeddedResource(typeof(TestUtilities).Assembly, resource)),
            };

        /// <summary>
        /// Reads an embedded resource from an assembly. In the Visual Studio project, be sure to
        /// set the Build Action of the file in solution explorer to "Embedded Resource".
        /// </summary>
        /// <param name="assembly">The assembly (project) to that contains the embedded resource</param>
        /// <param name="embeddedResourceName">The resource name, usually something like "fileName.xml".</param>
        /// <returns></returns>
        private static string ReadStringFromEmbeddedResource(Assembly assembly, string embeddedResourceName)
        {
            string resourceName = assembly.GetManifestResourceNames().FirstOrDefault(name =>
                name.EndsWith(embeddedResourceName, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentException($"Unable to locate the resource named '{embeddedResourceName}'.");
            }

            using var reader = new StreamReader(assembly.GetManifestResourceStream(resourceName));
            return reader.ReadToEnd();
        }
    }
}
