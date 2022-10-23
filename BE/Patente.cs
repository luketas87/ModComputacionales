using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Patente : ComponentePermiso
    {
        public int patente_id
        {
            get; set;
        }
        public string patente_nombre
        {
            get; set;
        }

        public Patente()
        {

        }
        public Patente(int pId)
        {
            Id = pId;
        }

        public override IList<ComponentePermiso> Hijos
        {
            get
            {
                return new List<ComponentePermiso>();
            }

        }

        public override void AgregarHijo(ComponentePermiso c)
        {

        }

        public override void VaciarHijos()
        {

        }

    }
}
