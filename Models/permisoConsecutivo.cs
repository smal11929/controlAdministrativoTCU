//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace controlAdministrativo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class permisoConsecutivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public permisoConsecutivo()
        {
            this.boletaPermiso = new HashSet<boletaPermiso>();
        }
    
        public int id { get; set; }
        public int consecutivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<boletaPermiso> boletaPermiso { get; set; }
    }
}
