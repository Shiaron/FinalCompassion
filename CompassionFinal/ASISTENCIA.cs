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

    public partial class ASISTENCIA
    {

        [Display(Name = "Asistencia")]
        public int IDasistencia { get; set; }
        [Display(Name = "Niño")]
        public string idniño { get; set; }
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public System.DateTime fecha { get; set; }
        [Display(Name = "Asistencia")]
        public bool asistencia1 { get; set; }

    
        public virtual Niño Niño { get; set; }
    }
}
