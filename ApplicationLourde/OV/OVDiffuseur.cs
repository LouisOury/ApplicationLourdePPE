using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLourde.OV
{
    public class OVDiffuseur
    {
        #region Membres
        private int identifiant;
        private string nomEntreprise;
        private int identifiantCompte;

        private OVCompte ovCompte = new OVCompte();
        #endregion

        #region Propriétés
        public int Identifiant { get { return identifiant; } set { identifiant = value; } }
        public string NomEntreprise { get { return nomEntreprise; } set { nomEntreprise = value; } }
        public int IdentifiantCompte { get { return identifiantCompte; } set { identifiantCompte = value; } }
        public OVCompte OvCompte { get { return ovCompte; } set { ovCompte = value; } }
        #endregion
    }
}
