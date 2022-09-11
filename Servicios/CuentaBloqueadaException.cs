using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace Servicios
{
    public class CuentaBloqueadaException : Exception
    {
        public CuentaUsuario mCuentaUsuario;
        public string mNuevaClave;

        public CuentaBloqueadaException(CuentaUsuario pCuentaUsuario, string pClave)
        {
            mCuentaUsuario = pCuentaUsuario;
            mNuevaClave = pClave;
        }
    }
}
