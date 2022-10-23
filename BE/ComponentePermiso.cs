using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class ComponentePermiso
    {
        public string Nombre
        {
            get; set;
        }
        public int Id
        {
            get; set;
        }

        public abstract IList<ComponentePermiso> Hijos
        {
            get;
        }
        public abstract void AgregarHijo(ComponentePermiso c);
        public abstract void VaciarHijos();
        public TipoPermiso Permiso
        {
            get; set;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
