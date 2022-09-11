using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Servicios
{
    public class ControlArchivos
    {
        public static string rutaPredeterminada = @"..\..\..\";
        public string LeerArchivo(string pDireccion)
        {
            string text = System.IO.File.ReadAllText(pDireccion);
            return text;
        }

        public static void EscribirArchivo(string pNombreArchivo, string pCadena)
        {
            string pRuta = rutaPredeterminada + "/" + pNombreArchivo;
            File.WriteAllText(pRuta, pCadena);
        }

        public static void EscribirArchivo(string pRuta, string pNombreArchivo, string pCadena)
        {
            string mRuta = pNombreArchivo;
            File.WriteAllText(mRuta, pCadena);
        }
    }
}
