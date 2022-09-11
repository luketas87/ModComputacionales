using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BackupeadorDAL
    {
        public static int RealizarBackup(string pNombreArchivo, string pRuta, int pVolumenes)
        {
            DAO mDAObject = new DAO();
            string mBase = mDAObject.mCon.Database;
            string cadena = "BACKUP DATABASE " + mBase + " TO ";
            for (int i = 1; i <= pVolumenes; i++)
            {
                if (i < pVolumenes)
                {
                    cadena += " DISK = '" + pRuta + "/" + pNombreArchivo + i + ".bak',";
                }
                else
                {
                    cadena += " DISK = '" + pRuta + "/" + pNombreArchivo + i + ".bak'";
                }
            }
            return mDAObject.ExecuteNonQuery(cadena);
        }

        public static int RealizarRestore(string pNombreArchivo, string pRuta, int pVolumenes)
        {
            DAO mDAObject = new DAO();
            string mBase = mDAObject.mCon.Database;
            string cadena = "ALTER DATABASE " + mBase + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;RESTORE DATABASE " + mBase + " FROM";
            for (int i = 1; i <= pVolumenes; i++)
            {
                if (i < pVolumenes)
                {
                    cadena += " DISK = '" + pRuta + "/" + pNombreArchivo + i + ".bak',";
                }
                else
                {
                    cadena += " DISK = '" + pRuta + "/" + pNombreArchivo + i + ".bak'";
                }
            }
            cadena += " WITH REPLACE";
            return mDAObject.ExecuteNonQuery(cadena, "master");
        }
    }
}
