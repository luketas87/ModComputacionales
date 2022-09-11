using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using Servicios;

namespace BLL
{
    public class CuentaUsuarioBL
    {
        public static List<CuentaUsuario> Listar()
        {
            return CuentaUsuarioDAL.Listar();
        }

        public static CuentaUsuario Obtener(int pId)
        {
            CuentaUsuario mCuentaUsuario = CuentaUsuarioDAL.Obtener(pId);
            if (mCuentaUsuario is null) { mCuentaUsuario = new CuentaUsuario(); }
            return mCuentaUsuario;
        }

        public static CuentaUsuario Obtener(string pUsername)
        {
            CuentaUsuario mCuentaUsuario = CuentaUsuarioDAL.Obtener(pUsername);
            if (mCuentaUsuario is null) { mCuentaUsuario = new CuentaUsuario(); }
            return mCuentaUsuario;
        }

        public static bool ValidarPassword(CuentaUsuario pCuentaUsuario, string pPass)
        {
            bool aux;
            if (pCuentaUsuario.Cuenta_usuario_password == pPass) { aux = true; }
            else
            {
                aux = false;
            }
            return aux;
        }

        public static int ModificarContrasenia(CuentaUsuario pCuentaUsuario, string pContrasenia)
        {
            pCuentaUsuario.Cuenta_usuario_password = pContrasenia;
            return Guardar(pCuentaUsuario);
        }
        public static CuentaUsuario ValidarLogin(string pUsername, string pPassword)
        {
            Encriptador mEncriptador = new Encriptador();
            CuentaUsuario mCuentaUsuario = Obtener(mEncriptador.EncriptarReversible(pUsername));
            Bitacora mRegistro = new Bitacora();
            mRegistro.cuenta_usuario_id = mCuentaUsuario.Cuenta_usuario_id;
            mRegistro.bitacora_fecha = DateTime.Now;
            mRegistro.bitacora_hora = DateTime.Now.TimeOfDay;
            if (mCuentaUsuario.Cuenta_usuario_id == 0 | mCuentaUsuario.cuenta_usuario_activa == 0)
            {
                mRegistro.cuenta_usuario_id = -1;
                mRegistro.bitacora_transaccion_id = 2;
                mRegistro.bitacora_criticidad = 3;
                BitacoraBL.Guardar(mRegistro);
                throw new UsuarioInexistenteException();
            }

            bool aux = ValidarPassword(mCuentaUsuario, mEncriptador.EncriptarIrreversible(pPassword));
            if (aux == false)
            {
                mCuentaUsuario.Cuenta_usuario_intentos_login += 1;
                mRegistro.cuenta_usuario_id = mCuentaUsuario.Cuenta_usuario_id;
                mRegistro.bitacora_transaccion_id = 3;
                mRegistro.bitacora_criticidad = 2;

                if (mCuentaUsuario.Cuenta_usuario_intentos_login == 3)
                {
                    string mNuevaClave = GenerarClaveAleatoria();
                    mCuentaUsuario.Cuenta_usuario_password = mEncriptador.EncriptarIrreversible(mNuevaClave);
                    //ControlArchivos.EscribirArchivo("NuevaClave.txt", mNuevaClave);
                    mCuentaUsuario.Cuenta_usuario_intentos_login = 0;
                    mRegistro.bitacora_transaccion_id = 4;
                    mRegistro.bitacora_criticidad = 1;
                    BitacoraBL.Guardar(mRegistro);
                    Guardar(mCuentaUsuario);
                    throw new CuentaBloqueadaException(mCuentaUsuario, mNuevaClave);
                }
                Guardar(mCuentaUsuario);
                BitacoraBL.Guardar(mRegistro);
                throw new ContraseniaIncorrectaException(mCuentaUsuario);
            }
            else { mCuentaUsuario.Cuenta_usuario_intentos_login = 0;
                mRegistro.cuenta_usuario_id = mCuentaUsuario.Cuenta_usuario_id;
                mRegistro.bitacora_transaccion_id = 1;
                mRegistro.bitacora_criticidad = 3;
                BitacoraBL.Guardar(mRegistro); }
                Guardar(mCuentaUsuario);
            CuentaUsuarioBL.ObtenerFamilias(mCuentaUsuario);
            return mCuentaUsuario;
        }

        public static void Logout(CuentaUsuario pUser)

        {
            Bitacora mRegistro = new Bitacora();
            mRegistro.bitacora_criticidad = 4;
            mRegistro.bitacora_transaccion_id = 6;
            mRegistro.cuenta_usuario_id = pUser.Cuenta_usuario_id;
            mRegistro.bitacora_fecha = DateTime.Now;
            mRegistro.bitacora_hora = DateTime.Now.TimeOfDay;
            BitacoraBL.Guardar(mRegistro);
        }

        public static string GenerarClaveAleatoria()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public static int Guardar(CuentaUsuario pCuentaUsuario)
        {
            int a = CuentaUsuarioDAL.Guardar(pCuentaUsuario);
            return a;
        }
        public static int Eliminar(CuentaUsuario pCuentaUsuario)
        {
            List<CuentaUsuario> mCuentas = Listar();
            if (mCuentas.Count >= 2)
            {
                List<Patente> mPatentesExcepto = PatenteBL.ListarExcepto(pCuentaUsuario);

                if (mPatentesExcepto.Count == 0)
                {
                    int a;

                    List<Patente> mPatente = ObtenerPatentes(pCuentaUsuario);
                    foreach (Patente x in mPatente)
                    {
                        EliminarPatente(x, pCuentaUsuario);
                    }
                    a = CuentaUsuarioDAL.Eliminar(pCuentaUsuario);
                    return a;
                }
                else
                {
                    PatentesSinAsignarException ex = new PatentesSinAsignarException();
                    ex.mPatentesSinAsignar = mPatentesExcepto;
                    throw ex;
                }
            }
            else throw new NoQuedanUsuariosException();
        }

        public static List<Patente> ObtenerPatentes(CuentaUsuario pCuentaUsuario)
        {
            List<Patente> mPatentes = CuentaUsuarioDAL.ObtenerPatentes(pCuentaUsuario);
            return mPatentes;
        }

        public static List<Familia> ObtenerFamilias(CuentaUsuario pCuentaUsuario)
        {
            List<Familia> mFamilias = CuentaUsuarioDAL.ObtenerFamilias(pCuentaUsuario);
            foreach (Familia mFam in mFamilias)
            {
                mFam.mPatentes =FamiliaBL.ObtenerPatentes(mFam);
            }

            return mFamilias;
        }

        public static List<Patente> ListarPermisosDisponibles(CuentaUsuario pCuentaUsuario)
        {
            List<Patente> mPermisos = new List<Patente>();
            mPermisos = ObtenerPatentes(pCuentaUsuario);
            List<Familia> mFamilias = ObtenerFamilias(pCuentaUsuario);
            foreach (Familia x in mFamilias)
            {
                List<Patente> mPatentesAux = FamiliaBL.ObtenerPatentes(x);
                mPermisos.AddRange(mPatentesAux);
            }
            return mPermisos;
        }

        public static bool VerificarPatente(int pPatenteId, CuentaUsuario pCuentaUsuario)
        {
            List<Patente> mPermisos = ListarPermisosDisponibles(pCuentaUsuario);
            bool resultado = mPermisos.Any(x => x.patente_id == pPatenteId);
            return resultado;
        }

        public static int AgregarPatente(Patente pPatente, CuentaUsuario pCuentaUsuario)
        {
            bool mAsignada = VerificarPatente(pPatente.patente_id, pCuentaUsuario);
            if (mAsignada == false)
            {
                CuentaUsuarioDAL.AgregarPatente(pPatente, pCuentaUsuario);
                DVHBL.ActualizarDV("cuenta_usuario_patente", pCuentaUsuario.Cuenta_usuario_id, pPatente.patente_id);
                return 1;
            }
            else
            {
                throw new PatenteYaAsignadaException();
            }
        }

        public static int EliminarPatente(Patente pPatente, CuentaUsuario pCuentaUsuario)
        {
            int aux = 0;

            List<CuentaUsuario> mCuentasUsuario = PatenteBL.ListarUsuarios(pPatente);

            if (mCuentasUsuario.Count > 1)
            {
                aux = CuentaUsuarioDAL.EliminarPatente(pPatente, pCuentaUsuario);
                DVVBL.ActualizarDVV("cuenta_usuario_patente");
            }
            else
            {
                PatentesSinAsignarException ex = new PatentesSinAsignarException();
                throw ex;
            }

            return aux;
        }
        public static int AgregarFamilia(Familia pFamilia, CuentaUsuario pCuentaUsuario)
        {
            int aux = CuentaUsuarioDAL.AgregarFamilia(pFamilia, pCuentaUsuario);
            DVHBL.ActualizarDV("cuenta_usuario_familia", pCuentaUsuario.Cuenta_usuario_id, pFamilia.familia_id);
            return aux;
        }

        public static int EliminarFamilia(Familia pFamilia, CuentaUsuario pCuentaUsuario)
        {
            int aux = CuentaUsuarioDAL.EliminarFamilia(pFamilia, pCuentaUsuario);
            DVVBL.ActualizarDVV("cuenta_usuario_familia");
            return aux;
        }
        public static List<CuentaUsuario> ObtenerUsuarios(Familia pFamilia)
        {
            return CuentaUsuarioDAL.ObtenerUsuarios(pFamilia);
        }
    }
}
