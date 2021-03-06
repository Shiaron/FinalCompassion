//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompassionFinal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class INCIDENTE_MEDICO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INCIDENTE_MEDICO()
        {
            this.DETALLE_ENFERMEDAD = new HashSet<DETALLE_ENFERMEDAD>();
            this.DETALLE_LESION = new HashSet<DETALLE_LESION>();
        }
    
        public int IDincidente { get; set; }
        [Required]
        public string idniño { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "F/Incidente")]
        public System.DateTime fecha { get; set; }
        [Required]
        public int tipo { get; set; }
        [Required]
        public double monto_desembolsado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ENFERMEDAD> DETALLE_ENFERMEDAD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_LESION> DETALLE_LESION { get; set; }
        public virtual Niño Niño { get; set; }
        public virtual Tipo Tipo1 { get; set; }
    }
}
