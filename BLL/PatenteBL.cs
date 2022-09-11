using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class PatenteBL
    {
        public static List<Patente> Listar()
        {
            return PatenteDAL.Listar();
        }

        public static int Guardar(Patente pPatente)
        {
            return PatenteDAL.Guardar(pPatente);
        }

        public static Patente Obtener(int pId)
        {
            Patente mPatente = PatenteDAL.Obtener(pId);
            return mPatente;
        }
        public static Patente Obtener(string pNombre)
        {
            Patente mPatente = PatenteDAL.Obtener(pNombre);
            return mPatente;
        }
        public static List<Patente> ListarExcepto(CuentaUsuario pCuentaUsuario)
        {
            List<Patente> mPatentes = PatenteDAL.ListarExcepto(pCuentaUsuario);
            return mPatentes;
        }
        public static int EncriptarTodo()
        {
            List<Patente> mPatentes = Listar();
            Encriptador mCripto = new Encriptador();
            foreach (Patente x in mPatentes)
            {
                x.patente_nombre = mCripto.EncriptarReversible(x.patente_nombre);
                PatenteDAL.Guardar(x);
            }
            return 1;
        }

        public static List<CuentaUsuario> ListarUsuarios(Patente pPatente)
        {
            return PatenteDAL.ListarUsuarios(pPatente);
        }
    }
}
