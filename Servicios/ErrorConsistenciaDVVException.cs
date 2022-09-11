using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace Servicios
{
    public class ErrorConsistenciaDVVException : Exception
    {
        public DVV mDVV;

        public ErrorConsistenciaDVVException(DVV pDVV)
        {
            mDVV = pDVV;
        }
    }
}
