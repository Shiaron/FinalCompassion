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

    public partial class GRUPO_CLASE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GRUPO_CLASE()
        {
            this.DETALLE_HORARIO = new HashSet<DETALLE_HORARIO>();
            this.Niño = new HashSet<Niño>();
        }
 
        public int IDgrupo { get; set; }
        [Required]
        [Display(Name = "Clase:")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Año:")]
        public int AÑO { get; set; }
        [Required]
        [Display(Name = "Periodo:")]
        public int PERIODO { get; set; }
        [Required]
        [Display(Name = "Tutor")]
        public int TUTOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_HORARIO> DETALLE_HORARIO { get; set; }
        public virtual PERIODO PERIODO1 { get; set; }
        public virtual TUTOR TUTOR1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Niño> Niño { get; set; }
    }
}