//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Platform.Entity.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actividad
    {
        public Actividad()
        {
            this.Recurso_Tarea = new HashSet<Recurso_Tarea>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public string descripcion { get; set; }
        public int Proyecto_id { get; set; }
        public int Integrante_id { get; set; }
    
        public virtual Integrante Integrante { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual ICollection<Recurso_Tarea> Recurso_Tarea { get; set; }
    }
}
