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
    
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            this.offres = new HashSet<offre>();
        }
    
        public long Identifiant { get; set; }
        public string NomEntreprise { get; set; }
        public string NomResponsable { get; set; }
        public string PrenomResponsable { get; set; }
        public string CiviliteResponsable { get; set; }
        public string RueEntreprise { get; set; }
        public int CpEntreprise { get; set; }
        public string VilleEntreprise { get; set; }
        public string MailEntreprise { get; set; }
        public string FaxEntreprise { get; set; }
        public string TelephoneEntreprise { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<offre> offres { get; set; }
    }
}