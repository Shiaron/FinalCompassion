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
    using System.Linq;
    public partial class TUTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUTOR()
        {
            this.GRUPO_CLASE = new HashSet<GRUPO_CLASE>();
        }
        [Required]
        [Display(Name = "Tutor")]
        public int IDTutor { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public int grado_instruccion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "F/ Inicio")]
        public System.DateTime fecha_inicio_voluntariado { get; set; }
        public int estado { get; set; }
    
        public virtual ESTADO ESTADO1 { get; set; }
        public virtual GRADO_INSTRUCCION GRADO_INSTRUCCION1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRUPO_CLASE> GRUPO_CLASE { get; set; }
    }
}