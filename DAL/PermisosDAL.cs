using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class PermisosDAL
    {
        public static int mId;
        public static int ProximoId()
        {
            if (mId == 0)
            {
                DAO mDAObject = new DAO();
                mId = mDAObject.ObtenerId("Cuenta_usuario");
            }
            mId += 1;
            return mId;
        }

        public static Array GetAllPermission()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }

        public static void EliminarFamilia(Familia pFamilia)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = "delete from permiso_permiso where permiso_padre_id = " + pFamilia.Id;
            mDAObject.ExecuteNonQuery(pCadenaComando);
            pCadenaComando = "delete from usuario_permiso where permiso_id = " + pFamilia.Id;
            mDAObject.ExecuteNonQuery(pCadenaComando);
            pCadenaComando = "delete from permiso where permiso_id = " + pFamilia.Id;
            mDAObject.ExecuteNonQuery(pCadenaComando);
        }

        public static ComponentePermiso GuardarComponente(ComponentePermiso p, bool esfamilia)
        {
            try
            {
                DAO mDAObject = new DAO();
                string pCadenaComando;
                p.Id = ProximoId();

                if (esfamilia)
                {
                    pCadenaComando = "insert into permiso(permiso_id, permiso_nombre, permiso_desc) values (" + p.Id + ", '" + p.Nombre + "', '')";
                    GuardarFamilia((Familia)p);
                }
                else
                    pCadenaComando = "insert into permiso(permiso_id, permiso_nombre, permiso_desc) values (" + p.Id + ", '" + p.Nombre + "', '" + p.Permiso + "')";

                mDAObject.ExecuteNonQuery(pCadenaComando);
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }


        }
        public static void GuardarFamilia(Familia c)
        {
            try
            {
                DAO mDAObject = new DAO();
                string pCadenaComando;
                pCadenaComando = "delete from permiso_permiso where id_permiso_padre = " + c.Id;
                mDAObject.ExecuteNonQuery(pCadenaComando);

                foreach (var item in c.Hijos)
                {
                    string pCadena = "insert into permiso_permiso (permiso_padre_id, permiso_hijo_id) values (" + c.Id + ", " + item.Id + ")";
                    mDAObject.ExecuteNonQuery(pCadenaComando);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void ValorizarEntidad(Patente pPatente, DataRow pDr)
        {
            pPatente.Id = int.Parse(pDr["Permiso_id"].ToString());
            pPatente.Nombre = pDr["permiso_nombre"].ToString();
            pPatente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), pDr["permiso_desc"].ToString());
        }

        public static void ValorizarEntidad(Familia pFamilia, DataRow pDr)
        {
            pFamilia.Id = int.Parse(pDr["Permiso_id"].ToString());
            pFamilia.Nombre = pDr["permiso_nombre"].ToString();
        }

        public static IList<Patente> GetAllPatentes()
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = $@"select * from permiso p where p.permiso_desc is not null;";
            List<Patente> mPatentes = new List<Patente>();
            DataSet mDs = new DataSet();
            mDs = mDAObject.ExecuteDataSet(pCadenaComando);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Patente mPatente = new Patente(int.Parse(mDr["Permiso_id"].ToString()));
                    ValorizarEntidad(mPatente, mDr);
                    mPatentes.Add(mPatente);
                }
            }
            return mPatentes;
        }

        public static IList<Familia> GetAllFamilias()
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = $@"select * from permiso p where p.permiso_desc is null;";
            List<Familia> mFamilias = new List<Familia>();
            DataSet mDs = new DataSet();
            mDs = mDAObject.ExecuteDataSet(pCadenaComando);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Familia mFamilia = new Familia(int.Parse(mDr["Permiso_id"].ToString()));
                    ValorizarEntidad(mFamilia, mDr);
                    GetHijos(mFamilia);
                    mFamilias.Add(mFamilia);
                }
            }
            return mFamilias;
        }

        public static void GetHijos(Familia pFamilia)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            List<Patente> mPatentes = new List<Patente>();
            pCadenaComando = "Select p.permiso_id, p.permiso_nombre, p.permiso_desc from permiso_permiso pp join permiso p on pp.permiso_hijo_id = p.permiso_id where pp.permiso_padre_id = " + pFamilia.Id;
            DataSet mDs = new DataSet();
            mDs = mDAObject.ExecuteDataSet(pCadenaComando);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Patente mPatente = new Patente(int.Parse(mDr["Permiso_id"].ToString()));
                    ValorizarEntidad(mPatente, mDr);
                    pFamilia.AgregarHijo(mPatente);
                }
            }
        }

        public static IList<ComponentePermiso> GetPermissions()
        {
            List<ComponentePermiso> mPermisos = new List<ComponentePermiso>();
            mPermisos.AddRange(GetAllPatentes());
            mPermisos.AddRange(GetAllFamilias());
            return mPermisos;
        }
        public static List<ComponentePermiso> GetPermissions(CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            List<ComponentePermiso> mPermisos = new List<ComponentePermiso>();
            pCadenaComando = "select P.permiso_id, P.permiso_nombre, P.permiso_desc from usuario_permiso UP left join permiso P on UP.permiso_id = P.permiso_id where P.permiso_desc is not null and UP.usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            DataSet mDs = new DataSet();
            mDs = mDAObject.ExecuteDataSet(pCadenaComando);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Patente mPatente = new Patente(int.Parse(mDr["Permiso_id"].ToString()));
                    ValorizarEntidad(mPatente, mDr);
                    mPermisos.Add(mPatente);
                }
            }
            pCadenaComando = "select P.permiso_id, P.permiso_nombre, P.permiso_desc from usuario_permiso UP left join permiso P on UP.permiso_id = P.permiso_id where P.permiso_desc is null and UP.usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            mDs = mDAObject.ExecuteDataSet(pCadenaComando);
            if (mDs.Tables.Count > 0 && mDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mDr in mDs.Tables[0].Rows)
                {
                    Familia mFamilia = new Familia(int.Parse(mDr["Permiso_id"].ToString()));
                    ValorizarEntidad(mFamilia, mDr);
                    GetHijos(mFamilia);
                    mPermisos.Add(mFamilia);
                }
            }
            return mPermisos;
        }

        public static void GuardarPermisos(CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = "delete from usuario_permiso where usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            mDAObject.ExecuteNonQuery(pCadenaComando);
            foreach (ComponentePermiso P in pCuentaUsuario.Permisos)
            {
                pCadenaComando = "insert into usuario_permiso values(" + pCuentaUsuario.Cuenta_usuario_id + ", " + P.Id + ")";
                mDAObject.ExecuteNonQuery(pCadenaComando);
            }
        }

        public static void EliminarPermisos(CuentaUsuario pCuentaUsuario)
        {
            DAO mDAObject = new DAO();
            string pCadenaComando;
            pCadenaComando = "delete from usuario_permiso where usuario_id = " + pCuentaUsuario.Cuenta_usuario_id;
            mDAObject.ExecuteNonQuery(pCadenaComando);
        }
    }
}
