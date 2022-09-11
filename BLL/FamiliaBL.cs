using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class FamiliaBL
    {
        public static List<Familia> Listar()
        {
            return FamiliaDAL.Listar();
        }

        public static int Guardar(Familia pFamilia)
        {
            return FamiliaDAL.Guardar(pFamilia);
        }

        public static Familia Obtener(int pId)
        {
            Familia mFamilia = FamiliaDAL.Obtener(pId);
            return mFamilia;
        }
        public static Familia Obtener(string pNombre)
        {
            Familia mFamilia = FamiliaDAL.Obtener(pNombre);
            return mFamilia;
        }
        public static List<Patente> ObtenerPatentes(Familia pFamilia)
        {
            List<Patente> mPatentes = FamiliaDAL.ObtenerPatentes(pFamilia);
            return mPatentes;
        }
        public static int EncriptarTodo()
        {
            List<Familia> mFamilias = Listar();
            Encriptador mCripto = new Encriptador();
            foreach (Familia x in mFamilias)
            {
                x.familia_nombre = mCripto.EncriptarReversible(x.familia_nombre);
                FamiliaDAL.Guardar(x);
            }
            return 1;
        }
        public static void Eliminar(Familia pFamilia)
        {
            List<Patente> mPatentes = ObtenerPatentes(pFamilia);
            List<CuentaUsuario> mCuentasUsuario = CuentaUsuarioBL.ObtenerUsuarios(pFamilia);
            if (mCuentasUsuario != null)
            {
                foreach (CuentaUsuario x in mCuentasUsuario)
                {
                    CuentaUsuarioBL.EliminarFamilia(pFamilia, x);
                }
                DVVBL.ActualizarDVV("cuenta_usuario_familia");
            }
            if (mPatentes != null)
            {
                foreach (Patente x in mPatentes)
                {
                    EliminarPatente(pFamilia, x);
                }
                DVVBL.ActualizarDVV("familia_patente");
            }
            FamiliaDAL.Eliminar(pFamilia);
        }

        public static int AgregarPatente(Familia pFamilia, Patente pPatente)
        {
            if (VerificarPatente(pPatente.patente_id, pFamilia) == false)
            {
                FamiliaDAL.AgregarPatente(pFamilia, pPatente);
                DVHBL.ActualizarDV("familia_patente", pFamilia.familia_id, pPatente.patente_id);
            }
            else
            {
                throw new PatenteYaAsignadaException();
            }
            return 1;
        }
        public static bool VerificarPatente(int pPatenteId, Familia pFamilia)
        {
            List<Patente> mPatentes = ObtenerPatentes(pFamilia);
            if (mPatentes != null)
            {
                bool resultado = mPatentes.Any(x => x.patente_id == pPatenteId);
                return resultado;
            }
            else return false;
        }
        public static int EliminarPatente(Familia pFamilia, Patente pPatente)
        {
            int aux = FamiliaDAL.EliminarPatente(pFamilia, pPatente);
            DVVBL.ActualizarDVV("familia_patente");
            return aux;
        }
    }
}
