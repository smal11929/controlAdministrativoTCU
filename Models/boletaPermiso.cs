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
    
    public partial class boletaPermiso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public boletaPermiso()
        {
            this.permisoComprobante = new HashSet<permisoComprobante>();
        }
    
        public int id { get; set; }
        public System.DateTime fecha { get; set; }
        public string departamento { get; set; }
        public string nombreFuncionario { get; set; }
        public string cedulaFuncionario { get; set; }
        public string permisoAusencia { get; set; }
        public string najoHorario { get; set; }
        public string permisoRetiro { get; set; }
        public string justificarAusencia { get; set; }
        public string justificarLlegadaTardia { get; set; }
        public byte[] adjunto { get; set; }
        public string estado { get; set; }
        public byte[] sello { get; set; }
        public string aprobadoPor { get; set; }
        public string firmadoPor { get; set; }
        public Nullable<int> consecutivo { get; set; }
        public Nullable<int> idConsecutivo { get; set; }
    
        public virtual permisoConsecutivo permisoConsecutivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permisoComprobante> permisoComprobante { get; set; }
    }
}
