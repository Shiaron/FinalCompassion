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
    public partial class DETALLE_INMUNIZACIONES
    {
        public int IDInmunizacion { get; set; }
        [Required]
        [Display(Name = "Niño")]
        public string idniño { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public System.DateTime fecha { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public int tipo_inmunizacion { get; set; }
        [Required]
        [Display(Name = "N° Dosis")]
        public int dosis { get; set; }
      
        [Display(Name = "Estado")]
        public string estado { get; set; }
    
        public virtual DOSIS DOSIS1 { get; set; }
        public virtual Niño Niño { get; set; }
        public virtual TIPO_INMUNIZACION TIPO_INMUNIZACION1 { get; set; }
    }
}