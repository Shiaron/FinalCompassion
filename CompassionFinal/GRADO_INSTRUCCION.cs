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
    
    public partial class GRADO_INSTRUCCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GRADO_INSTRUCCION()
        {
            this.TUTOR = new HashSet<TUTOR>();
        }
    
        public int IDgrado { get; set; }
        public string nombres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUTOR> TUTOR { get; set; }
    }
}
