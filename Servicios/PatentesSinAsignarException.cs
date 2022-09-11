using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace Servicios
{
    public class PatentesSinAsignarException : Exception
    {
        public List<Patente> mPatentesSinAsignar
        {
            get; set;
        }
    
    }
}
