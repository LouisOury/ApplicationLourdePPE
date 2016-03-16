using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLourde.OV
{
    public class OVDomaine
    {
        #region Membres
        private int identifiant;
        private string libelle;
        #endregion

        #region Propriétés
        public int Identifiant { get { return identifiant; } set { identifiant = value; } }
        public string Libelle { get { return libelle; } set { libelle = value; } }
        #endregion
    }
}
