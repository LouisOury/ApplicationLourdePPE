using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLourde.OV
{
    public class OVClient
    {
        #region Membres
        private int identifiant;
        private string nomEntreprise;
        private string nomResponsable;
        private string prenomResponsable;
        private string civiliteResponsable;
        private string rueEntreprise;
        private int cpEntreprise;
        private string villeEntreprise;
        private string mailEntreprise;
        private string faxEntreprise;
        private string telephoneEntreprise;

        #endregion

        #region Propriétés
        public int Identifiant { get { return identifiant; } set { identifiant = value; } }
        public string NomEntreprise { get { return nomEntreprise; } set { nomEntreprise = value; } }
        public string NomResponsable { get { return nomResponsable; } set { nomResponsable = value; } }
        public string PrenomResponsable { get { return prenomResponsable; } set { prenomResponsable = value; } }
        public string CiviliteResponsable { get { return civiliteResponsable; } set { civiliteResponsable = value; } }
        public string RueEntreprise { get { return rueEntreprise; } set { rueEntreprise = value; } }
        public int CpEntreprise { get { return cpEntreprise; } set { cpEntreprise = value; } }
        public string VilleEntreprise { get { return villeEntreprise; } set { villeEntreprise = value; } }
        public string MailEntreprise { get { return mailEntreprise; } set { mailEntreprise = value; } }
        public string FaxEntreprise { get { return faxEntreprise; } set { faxEntreprise = value; } }
        public string TelephoneEntreprise { get { return telephoneEntreprise; } set { telephoneEntreprise = value; } }
        #endregion
    }
}
