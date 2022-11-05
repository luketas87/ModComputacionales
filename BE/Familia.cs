using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Familia : ComponentePermiso
    {
        public int familia_id
        {
            get; set;
        }
        public string familia_nombre
        {
            get; set;
        }

        public List<Patente> mPatentes;

        //public Familia()
        //{
        //    mPatentes = new List<Patente>();
        //}

        public Familia(int pId)
        {
            mPatentes = new List<Patente>();
            Id = pId;
            _hijos = new List<ComponentePermiso>();
        }

        private IList<ComponentePermiso> _hijos;
        public Familia()
        {
            _hijos = new List<ComponentePermiso>();
        }

        public override IList<ComponentePermiso> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }

        public override void VaciarHijos()
        {
            _hijos = new List<ComponentePermiso>();
        }
        public override void AgregarHijo(ComponentePermiso c)
        {
            if(c!=null) _hijos.Add(c);
        }
    }
}
