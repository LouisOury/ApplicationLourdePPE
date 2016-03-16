using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLourde.OV
{
    public class OVMetier
    {
        #region Membres
        private int identifiant;
        private string libelle;
        private int identifiantDomaine;

        private OVDomaine ovDomaine = new OVDomaine();
        #endregion

        #region Propriétés
        public int Identifiant { get { return identifiant; } set { identifiant = value; } }
        public string Libelle { get { return libelle; } set { libelle = value; } }
        public int IdentifiantDomaine { get { return identifiantDomaine; } set { identifiantDomaine = value; } }
        public OVDomaine OvDomaine { get { return ovDomaine; } set { ovDomaine = value; } }
        #endregion
    }
}
