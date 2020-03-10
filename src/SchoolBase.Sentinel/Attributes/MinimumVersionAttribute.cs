using SchoolBase.Sentinel.Areas.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    sealed class MinimumVersionAttribute : Attribute
    {

        // This is a positional argument
        public MinimumVersionAttribute(int yearVersion, int monthVersion, int iterationVersion)
        {
            Version = new Version(yearVersion, monthVersion, iterationVersion);
        }

        public Version Version { get; }
    }
}
