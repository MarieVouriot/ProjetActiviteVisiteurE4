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
    
    public partial class medicament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medicament()
        {
            this.offrir = new HashSet<offrir>();
        }
    
        public string MED_DEPOTLEGAL { get; set; }
        public string MED_NOMCOMMERCIAL { get; set; }
        public string MED_COMPOSITION { get; set; }
        public string MED_EFFET { get; set; }
        public string MED_CONTREINDIC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<offrir> offrir { get; set; }
    }
}