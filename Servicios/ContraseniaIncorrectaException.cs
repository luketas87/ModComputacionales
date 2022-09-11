using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace Servicios
{
    public class ContraseniaIncorrectaException : Exception
    {
        public CuentaUsuario mCuentaUsuario;

        public ContraseniaIncorrectaException(CuentaUsuario pCuentaUsuario)
        {
            mCuentaUsuario = pCuentaUsuario;
        }
    }
}
