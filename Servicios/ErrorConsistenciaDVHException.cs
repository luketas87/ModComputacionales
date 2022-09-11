using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace Servicios
{
    public class ErrorConsistenciaDVHException : Exception
    {
        public DVH mDVH;
    }
}
