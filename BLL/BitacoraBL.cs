using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class BitacoraBL
    {
        public static int Guardar(Bitacora pBitacora)
        {
            int i = BitacoraDAL.Guardar(pBitacora);
            DVV x = DVVBL.Obtener("bitacora");   
            x.valorDVV = DVVBL.CalcularDVV(x.tabla);
            bool aux = DVVBL.ValidarDVV(x);
            if (aux == true)
            {
                DVHBL.ActualizarDV("bitacora", pBitacora.bitacora_id);
            }
            return i;
        }
        public static List<Bitacora> Listar()
        {
            return BitacoraDAL.Listar();
        }
        public static Bitacora Obtener(int pId)
        {
            return BitacoraDAL.Obtener(pId);
        }
        public static List<Bitacora> ListarRango(DateTime pFechaDesde, DateTime pFechaHasta)
        {
            return BitacoraDAL.ListarRango(pFechaDesde, pFechaHasta);
        }
        public static List<string> TiposMovimiento()
        {
            return BitacoraDAL.TiposMovimiento();
        }
    }
}
