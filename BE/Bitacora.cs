using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Bitacora
    {
        public int bitacora_id
        {
            get; set;
        }
        public int cuenta_usuario_id
        {
            get; set;
        }

        public int bitacora_criticidad
        {
            get; set;
        }
        public int bitacora_transaccion_id
        {
            get; set;
        }
        public string bitacora_transaccion
        {
            get; set;
        }
        public DateTime bitacora_fecha
        {
            get; set;
        }
        public TimeSpan bitacora_hora
        {
            get; set;
        }
        public Bitacora(int pId)
        {
            bitacora_id = pId;
        }
        public Bitacora(int pCuentaUsuario, int pCriticidad, int pIdTransaccion, DateTime pFecha, TimeSpan pHora)
        {
            cuenta_usuario_id = pCuentaUsuario;
            bitacora_criticidad = pCriticidad;
            bitacora_transaccion_id = pIdTransaccion;
            bitacora_fecha = pFecha;
            bitacora_hora = pHora;
        }

        public Bitacora()
        {
        }
    }
}
