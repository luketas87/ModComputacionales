using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace Servicios
{
    public class PatenteYaAsignadaException : Exception
    {
        public Patente mPatenteAsignada;

        public PatenteYaAsignadaException()
        {
        }
        public PatenteYaAsignadaException(Patente pPatente)
        {
            mPatenteAsignada = pPatente;
        }
    }
}
