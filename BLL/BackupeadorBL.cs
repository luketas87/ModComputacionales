using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class BackupeadorBL
    {
        public static int RealizarBackup(string pNombreArchivo, string pRuta, int pVolumenes)
        {
            return BackupeadorDAL.RealizarBackup(pNombreArchivo, pRuta, pVolumenes);
        }
        public static int RealizarRestore(string pNombreArchivo, string pRuta, int pVolumenes)
        {
            return BackupeadorDAL.RealizarRestore(pNombreArchivo, pRuta, pVolumenes);
        }
    }
}
