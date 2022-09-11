using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using Servicios;


namespace BLL
{
    public class DVHBL
    {
        public static List<DVH> ObtenerValoresDVH(string pTabla)
        {
            return DVHDAL.ObtenerValoresDVH(pTabla);
        }
        public static DVH ObtenerValorDVH(string pTabla, int PK1, int PK2)
        {
            return DVHDAL.ObtenerValorDVH(pTabla, PK1, PK2);
        }

        public static DVH ObtenerValorDVH(string pTabla, int PK1)
        {
            return DVHDAL.ObtenerValorDVH(pTabla, PK1);
        }

        public static bool ValidarValorDVH(DVH mDVH)
        {
            return mDVH.valorDVH == mDVH.valorDVHBase;
        }

        public static List<string> ListarDVHsAlterados()
        {
            List<string> mRegistros = new List<string>();
            mRegistros.Clear();

            List<DVV> mValores = DVVBL.Obtener();
            foreach (DVV y in mValores)
            {
                List<DVH> mDVH = ObtenerValoresDVH(y.tabla);
                foreach (DVH x in mDVH)
                {
                    bool resultado = ValidarValorDVH(x);
                    if (resultado == false)
                    {
                        mRegistros.Add("El registro ( " + x.clavePrimaria + ", " + x.clavePrimaria2 + ") de la tabla " + x.tabla +" fue alterado por fuera del sistema.");
                    }
                }
            }              
            return mRegistros;
        }

        public static bool ValidarTabla(string pTabla)
        {
            List<DVH> mDVH = ObtenerValoresDVH(pTabla);
            foreach (DVH x in mDVH)
            {
                bool resultado = ValidarValorDVH(x);
                if (resultado == false)
                {
                    ErrorConsistenciaDVHException ex = new ErrorConsistenciaDVHException();
                    ex.mDVH = x;
                    throw ex;
                }
            }
            return true;

        }
        public static int ActualizarDVH(string pTabla, DVH mDVH)
        {
            return DVHDAL.ActualizarDVH(pTabla, mDVH);
        }

        public static int ActualizarDVH(string pTabla, int PK, int PK2)
        {
            DVH mDVH = ObtenerValorDVH(pTabla, PK, PK2);
            return ActualizarDVH(pTabla, mDVH);
        }
        public static int ActualizarDV(string pTabla, int PK)
        {
            Encriptador mCripto = new Encriptador();
            DVH mDVH = ObtenerValorDVH(pTabla, PK);
            mDVH.valorDVHEncriptado = mCripto.EncriptarReversible(mDVH.valorDVH.ToString());
            ActualizarDVH(pTabla, mDVH);
            return DVVBL.ActualizarDVV(pTabla);
        }

        public static int ActualizarDV(string pTabla, int PK, int PK2)
        {
            Encriptador mCripto = new Encriptador();
            DVH mDVH = ObtenerValorDVH(pTabla, PK, PK2);
            mDVH.valorDVHEncriptado = mCripto.EncriptarReversible(mDVH.valorDVH.ToString());
            ActualizarDVH(pTabla, mDVH);
            return DVVBL.ActualizarDVV(pTabla);
        }

        public static List<int> ObtenerValorDVHTotal(string pTabla, int PK, int PK2)
        {
            return DVHDAL.ObtenerValorDVHTotal(pTabla, PK, PK2);
        }

        public static bool ValidarConsistenciaDVH()
        {
            List<string> mTablas = ListarTablas();
            foreach (string mTabla in mTablas)
            {
                ValidarTabla(mTabla);
            }
            return true;

        }
        
        public static List<string> ListarTablas()
        {
            List<string> mTablas = new List<string>();
            mTablas.Add("cuenta_usuario");
            mTablas.Add("bitacora");
            return mTablas;
        }

        public static bool CalcularTodos()
        {
            List<string> mTablas = ListarTablas();
            Encriptador mCripto = new Encriptador();
            foreach (string mTabla in mTablas)
            {
                List<DVH> mDVH = DVHDAL.ObtenerValoresDVH(mTabla);
                foreach (DVH x in mDVH)
                {
                    x.valorDVHEncriptado = mCripto.EncriptarReversible(x.valorDVH.ToString());
                    DVHDAL.ActualizarDVH(mTabla, x);
                }
            }
            return true;
        }
    }
}
