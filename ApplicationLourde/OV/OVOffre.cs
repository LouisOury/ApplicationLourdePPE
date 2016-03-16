using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLourde.OV
{
    public class OVOffre
    {
        #region Membres
        private int identifiant;
        private string libelle;
        private string reference;
        private DateTime dateDebutPublication;
        private DateTime dateFinPublication;
        private DateTime dateDebutContrat;
        private DateTime dateFinContrat;
        private string descriptionPoste;
        private string descriptionProfil;
        private int nombresPoste;
        private int identifiantClient;
        private int identifiantMetier;
        private int identifiantContrat;

        private OVClient ovClient = new OVClient();
        private OVMetier ovMetier = new OVMetier();
        private OVContrat ovContrat = new OVContrat();
        #endregion

        #region Propriétés
        public int Identifiant { get { return identifiant; } set { identifiant = value; } }
        public string Libelle { get { return libelle; } set { libelle = value; } }
        public string Reference { get { return reference; } set { reference = value; } }
        public DateTime DateDebutPublication { get { return dateDebutPublication; } set { dateDebutPublication = value; } }
        public DateTime DateFinPublication { get { return dateFinPublication; } set { dateFinPublication = value; } }
        public DateTime DateDebutContrat { get { return dateDebutContrat; } set { dateDebutContrat = value; } }
        public DateTime DateFinContrat { get { return dateFinContrat; } set { dateFinContrat = value; } }
        public string DescriptionPoste { get { return descriptionPoste; } set { descriptionPoste = value; } }
        public string DescriptionProfil { get { return descriptionProfil; } set { descriptionProfil = value; } }
        public int NombresPoste { get { return nombresPoste; } set { nombresPoste = value; } }
        public int IdentifiantClient { get { return identifiantClient; } set { identifiantClient = value; } }
        public int IdentifiantMetier { get { return identifiantMetier; } set { identifiantMetier = value; } }
        public int IdentifiantContrat { get { return identifiantContrat; } set { identifiantContrat = value; } }
        public OVClient OvClient { get { return ovClient; } set { ovClient = value; } }
        public OVMetier OvMetier { get { return ovMetier; } set { ovMetier = value; } }
        public OVContrat OvContrat { get { return ovContrat; } set { ovContrat = value; } }
        #endregion
    }
}
