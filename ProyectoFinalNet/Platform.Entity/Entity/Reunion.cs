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
    
    public partial class Reunion
    {
        public int id { get; set; }
        public string lugar { get; set; }
        public string tematica { get; set; }
        public int Proyecto_id { get; set; }
    
        public virtual Proyecto Proyecto { get; set; }
    }
}