//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionMegaCasting.DBLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class metier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public metier()
        {
            this.offres = new HashSet<offre>();
        }
    
        public long Identifiant { get; set; }
        public string Libelle { get; set; }
        public long IdentifiantDomaine { get; set; }
    
        public virtual domaine domaine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<offre> offres { get; set; }
    }
}