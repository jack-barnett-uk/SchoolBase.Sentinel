using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Exceptions
{
    [Serializable]
    public class NotAvailableException : Exception
    {
        public NotAvailableException(string endpoint, Version version)
            : base($"{endpoint} not available in version {version.ToString()}")
        {

        }
    }
}
