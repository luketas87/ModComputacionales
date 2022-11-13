using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using System.Threading.Tasks;

namespace BLL
{
    public class PermisoBL
    {
        public static List<ComponentePermiso> GetPermissions()
        {
            List<ComponentePermiso> list = new List<ComponentePermiso>();
            list.AddRange(PermisosDAL.GetAllFamilias());
            list.AddRange(PermisosDAL.GetAllPatentes());
            return list;
        }

        public static IList<Patente> GetAllPatentes()
        {
            return PermisosDAL.GetAllPatentes();
        }

        public static IList<Familia> GetAllFamilias()
        {
            return PermisosDAL.GetAllFamilias();
        }
        public static void GetPermissions(CuentaUsuario pCuentaUsuario)
        {
            pCuentaUsuario.Permisos = PermisosDAL.GetPermissions(pCuentaUsuario);
        }

        public static void GuardarPermisos(CuentaUsuario pCuentaUsuario)
        {
            PermisosDAL.GuardarPermisos(pCuentaUsuario);
        }

        public static void GuardarFamilia(Familia pFamilia)
        {
            PermisosDAL.GuardarFamilia(pFamilia);
        }

        public static void GuardarComponente(ComponentePermiso pComponente, bool esFamilia)
        {
            PermisosDAL.GuardarComponente(pComponente, esFamilia);
        }

        public static void EliminarFamilia(Familia pFamilia)
        {
            PermisosDAL.EliminarFamilia(pFamilia);
        }
        public static Array GetAllPermission()
        {
            return PermisosDAL.GetAllPermission();
        }

        public static void GetHijos(Familia pFamilia)
        {
             PermisosDAL.GetHijos(pFamilia);
        }

        public static List<Patente> ListarPermisos(CuentaUsuario pCuentaUsuario)
        {
            List<Patente> mPatentes = new List<Patente>();
            GetPermissions(pCuentaUsuario);
            List<Familia> mFamilias = (List<Familia>)(pCuentaUsuario.Permisos.OfType<BE.Familia>().ToList());
            foreach (Familia F in mFamilias)
            {
                GetHijos(F);
                mPatentes.AddRange((List<Patente>)F.Hijos.OfType<BE.Patente>().ToList());
            }
            mPatentes.AddRange((List<Patente>)pCuentaUsuario.Permisos.OfType<BE.Patente>().ToList());
            return mPatentes;
        }

        public static bool ValidarPermiso(CuentaUsuario pCuentaUsuario, int permisoId)
        {
            List<Patente> mPatentes = ListarPermisos(pCuentaUsuario);
            return mPatentes.Any(x => x.Id.Equals(permisoId));
        }

    }
}
