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

    public partial class DETALLE_HORARIO
    {
        public int IDDetHorario { get; set; }
        public int IDgrupo { get; set; }
        public int dias { get; set; }
    
        public virtual GRUPO_CLASE GRUPO_CLASE { get; set; }
        public virtual DIAS DIAS1 { get; set; }
    }
}