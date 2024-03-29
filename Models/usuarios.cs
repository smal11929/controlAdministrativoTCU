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
    
    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            this.auditoria = new HashSet<auditoria>();
            this.historial = new HashSet<historial>();
        }
    
        public int id { get; set; }
        public string cedula { get; set; }
        public string Nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int pin { get; set; }
        public string rol { get; set; }
        public string telefono { get; set; }
        public string departamento { get; set; }
        public Nullable<bool> habilitado { get; set; }
        public byte[] imagen { get; set; }
        public int idInstitucion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auditoria> auditoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historial> historial { get; set; }
        public virtual institucion institucion { get; set; }
    }
}
