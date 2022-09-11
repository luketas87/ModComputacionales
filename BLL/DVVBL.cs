using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class DVVBL
    {
        public static DVV Obtener(string pTabla)
        {
            return DVVDAL.Obtener(pTabla);
        }

        public static List<DVV> Obtener()
        {
            return DVVDAL.Obtener();
        }
        public static long CalcularDVV(string pTabla)
        {
            return DVVDAL.CalcularDVV(pTabla);
        }
        public static int ActualizarDVV(DVV pDVV)
        {
            return DVVDAL.ActualizarDVV(pDVV);
        }
        public static int ActualizarDVV(string pTabla)
        {
            DVV mDVV = Obtener(pTabla);
            mDVV.valorDVV = CalcularDVV(pTabla);
            return ActualizarDVV(mDVV);
        }
        public static bool ValidarDVV(DVV pDVV)
        {
            return pDVV.valorDVV == pDVV.valorDVVBase;
        }

        public static bool ValidarConsistenciaDVV()
        {
            List<DVV> mValores = Obtener();
            foreach (DVV x in mValores)
            {
                x.valorDVV = CalcularDVV(x.tabla);
                bool aux = ValidarDVV(x);
                if (aux == false)
                {
                    throw new ErrorConsistenciaDVVException(x);
                }
            }
            return true;
        }

        public static List<string> ListarDVVsAlterados()
        {
            List<string> mTablas = new List<string>();
            mTablas.Clear();
            List<DVV> mValores = Obtener();
            foreach (DVV x in mValores)
            {
                x.valorDVV = CalcularDVV(x.tabla);
                bool aux = ValidarDVV(x);
                if (aux == false)
                {
                    mTablas.Add("Se agregaron o eliminaron registros en la tabla" +  x.tabla);
                }
            }
            return mTablas;
        }


        public static bool CalcularTodo()
        {
            List<DVV> mDVV = DVVDAL.Obtener();
            foreach (DVV x in mDVV)
            {
                long aux = DVVDAL.CalcularDVV(x.tabla);
                x.valorDVV = aux;
                DVVDAL.ActualizarDVV(x);
            }
            return true;
        }
    }
}
