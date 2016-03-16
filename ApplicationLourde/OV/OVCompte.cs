using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLourde.OV
{
    public class OVCompte
    {
        #region Membres
        private int identifiant;
        private string pseudonyme;
        private string motDePasee;
        #endregion

        #region Propriétés
        public int Identifiant { get { return identifiant; } set { identifiant = value; } }
        public string Pseudonyme { get { return pseudonyme; } set { pseudonyme = value; } }
        public string MotDePasee { get { return motDePasee; } set { motDePasee = value; } }
        #endregion
    }
}
