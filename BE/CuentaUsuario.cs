using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class CuentaUsuario
    {
        public int Cuenta_usuario_id
        {
            get; set;
        }
        public string Cuenta_usuario_username
        {
            get; set;
        }
        public string Cuenta_usuario_password
        {
            get; set;
        }
        public int Cuenta_usuario_intentos_login
        {
            get; set;
        }
        public DateTime Cuenta_fecha_alta
        {
            get; set;
        }

        public int cuenta_usuario_activa { get; set; } = 1;
        public CuentaUsuario()
        {
        }
        public CuentaUsuario(int pId)
        {
            Cuenta_usuario_id = pId;
        }


        //public string Get
        public void SetFechaAlta(int dia, int mes, int anio)
        {
            Cuenta_fecha_alta = new DateTime(anio, mes, dia);
        }

        public string GetFechaAltaToString()
        {
            string aux = Cuenta_fecha_alta.Year + "-" + Cuenta_fecha_alta.Month + "-" + Cuenta_fecha_alta.Day;
            return aux;
        }
    }
}
