//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetActiviteVisiteurWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class inviter
    {
        public int AC_NUM { get; set; }
        public short PRA_NUM { get; set; }
        public bool SPECIALISTEON { get; set; }
    
        public virtual activite_compl activite_compl { get; set; }
        public virtual praticien praticien { get; set; }
    }
}
