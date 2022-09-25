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

    }
}
