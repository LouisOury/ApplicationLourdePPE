using ApplicationLourde.OV;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationLourde
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBConnect connect = new DBConnect();

        private OVClient ovClient;
        private OVDiffuseur ovDiffuseur;
        private OVOffre ovOffre;

        private ObservableCollection<OVClient> lstClient;
        private ObservableCollection<OVDiffuseur> lstDiffuseur;
        private ObservableCollection<OVOffre> lstOffre;
        private ObservableCollection<OVCompte> lstCompte;

        public ObservableCollection<OVClient> ListClients
        {
            get { return lstClient; }
            set { lstClient = value; }
        }
        public ObservableCollection<OVDiffuseur> ListDiffuseurs
        {
            get { return lstDiffuseur; }
            set { lstDiffuseur = value; }
        }
        public ObservableCollection<OVOffre> ListOffres
        {
            get { return lstOffre; }
            set { lstOffre = value; }
        }
        public ObservableCollection<OVCompte> ListComptes
        {
            get { return lstCompte; }
            set { lstCompte = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            connect.openConnect();

            AlimenterListeClient();
            AlimenterListeDiffuseur();
            AlimenterListeOffre();
            AlimenterListeCompte();

            ComboBoxPseudo(cbPseudo);
            ComboBoxClient(cbIdClt);
            ComboBoxMetier(cbIdMetier);
            ComboBoxContrat(cbIdCtr);

            this.DataContext = this;
        }

        #region Alimentation Listes / Combobox
        private void AlimenterListeClient()
        {
            lstClient = new ObservableCollection<OVClient>();
            string loadClient = "SELECT Identifiant, NomEntreprise, NomResponsable, PrenomResponsable, CiviliteResponsable, RueEntreprise, CpEntreprise, VilleEntreprise, MailEntreprise, FaxEntreprise, TelephoneEntreprise FROM client";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadClient;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            foreach (DataRowView rowView in ds.Tables[0].DefaultView)
            {
                OVClient ovClient = new OVClient();

                ovClient.Identifiant = int.Parse(rowView["Identifiant"].ToString());
                ovClient.NomEntreprise = rowView["NomEntreprise"].ToString();
                ovClient.NomResponsable = rowView["NomResponsable"].ToString();
                ovClient.PrenomResponsable = rowView["PrenomResponsable"].ToString();
                ovClient.CiviliteResponsable = rowView["CiviliteResponsable"].ToString();
                ovClient.RueEntreprise = rowView["RueEntreprise"].ToString();
                ovClient.CpEntreprise = int.Parse(rowView["CpEntreprise"].ToString());
                ovClient.VilleEntreprise = rowView["VilleEntreprise"].ToString();
                ovClient.MailEntreprise = rowView["MailEntreprise"].ToString();
                ovClient.FaxEntreprise = rowView["FaxEntreprise"].ToString();
                ovClient.TelephoneEntreprise = rowView["TelephoneEntreprise"].ToString();

                lstClient.Add(ovClient);
            }
        }
        private void AlimenterListeDiffuseur()
        {
            lstDiffuseur = new ObservableCollection<OVDiffuseur>();
            String loadDiffuseur = "SELECT diffuseur.Identifiant, NomEntreprise, IdentifiantCompte, Pseudonyme FROM diffuseur INNER JOIN compte ON diffuseur.IdentifiantCompte = compte.Identifiant";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadDiffuseur;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            foreach (DataRowView rowView in ds.Tables[0].DefaultView)
            {
                OVDiffuseur ovDiffuseur = new OVDiffuseur();

                ovDiffuseur.Identifiant = int.Parse(rowView["Identifiant"].ToString());
                ovDiffuseur.NomEntreprise = rowView["NomEntreprise"].ToString();
                ovDiffuseur.IdentifiantCompte = int.Parse(rowView["IdentifiantCompte"].ToString());
                ovDiffuseur.OvCompte.Pseudonyme = rowView["Pseudonyme"].ToString();

                lstDiffuseur.Add(ovDiffuseur);
            }
        }
        private void AlimenterListeOffre()
        {
            lstOffre = new ObservableCollection<OVOffre>();
            String loadOffre = "SELECT Identifiant, Libelle, Reference, DateDebutPublication, DateFinPublication, DateDebutContrat, DateFinContrat, DescriptionPoste, DescriptionProfil, NombresPoste, IdentifiantClient, IdentifiantMetier, IdentifiantContrat FROM offre";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadOffre;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            foreach (DataRowView rowView in ds.Tables[0].DefaultView)
            {
                OVOffre ovOffre = new OVOffre();

                ovOffre.Identifiant = int.Parse(rowView["Identifiant"].ToString());
                ovOffre.Libelle = rowView["Libelle"].ToString();
                ovOffre.Reference = rowView["Reference"].ToString();
                ovOffre.DateDebutPublication = Convert.ToDateTime(rowView["DateDebutPublication"].ToString());
                ovOffre.DateFinPublication = Convert.ToDateTime(rowView["DateFinPublication"].ToString());
                ovOffre.DateDebutContrat = Convert.ToDateTime(rowView["DateDebutContrat"].ToString());
                ovOffre.DateFinContrat = Convert.ToDateTime(rowView["DateFinContrat"].ToString());
                ovOffre.DescriptionPoste = rowView["DescriptionPoste"].ToString();
                ovOffre.DescriptionProfil = rowView["DescriptionProfil"].ToString();
                ovOffre.NombresPoste = int.Parse(rowView["NombresPoste"].ToString());
                ovOffre.IdentifiantClient = int.Parse(rowView["IdentifiantClient"].ToString());
                ovOffre.IdentifiantMetier = int.Parse(rowView["IdentifiantMetier"].ToString());
                ovOffre.IdentifiantContrat = int.Parse(rowView["IdentifiantContrat"].ToString());

                lstOffre.Add(ovOffre);
            }
        }
        private void AlimenterListeCompte()
        {
            lstCompte = new ObservableCollection<OVCompte>();
            String loadCompte = "SELECT Identifiant, Pseudonyme FROM compte";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadCompte;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            foreach (DataRowView rowView in ds.Tables[0].DefaultView)
            {
                OVCompte ovCompte = new OVCompte();

                ovCompte.Identifiant = int.Parse(rowView["Identifiant"].ToString());
                ovCompte.Pseudonyme = rowView["Pseudonyme"].ToString();

                lstCompte.Add(ovCompte);
            }
        }
        private void ComboBoxPseudo(ComboBox cbPseudo)
        {
            string loadCompte = "SELECT Identifiant FROM compte";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadCompte;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            cbPseudo.ItemsSource = ds.Tables[0].DefaultView;
            cbPseudo.DisplayMemberPath = ds.Tables[0].Columns["Identifiant"].ToString();
            cbPseudo.SelectedValuePath = ds.Tables[0].Columns["Identifiant"].ToString();
        }
        private void ComboBoxClient(ComboBox cbIdClt)
        {
            string loadCompte = "SELECT Identifiant, NomEntreprise FROM client";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadCompte;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            cbIdClt.ItemsSource = ds.Tables[0].DefaultView;
            cbIdClt.DisplayMemberPath = ds.Tables[0].Columns["Identifiant"].ToString();
            cbIdClt.SelectedValuePath = ds.Tables[0].Columns["Identifiant"].ToString();
        }
        private void ComboBoxMetier(ComboBox cbIdMetier)
        {
            string loadCompte = "SELECT Identifiant, Libelle FROM metier";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadCompte;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            cbIdMetier.ItemsSource = ds.Tables[0].DefaultView;
            cbIdMetier.DisplayMemberPath = ds.Tables[0].Columns["Identifiant"].ToString();
            cbIdMetier.SelectedValuePath = ds.Tables[0].Columns["Identifiant"].ToString();
        }
        private void ComboBoxContrat(ComboBox cbIdCtr)
        {
            string loadCompte = "SELECT Identifiant, Libelle FROM contrat";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = loadCompte;
            MySqlDataAdapter ad = new MySqlDataAdapter();
            ad.SelectCommand = cmd;
            cmd.Connection = connect.con;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            cbIdCtr.ItemsSource = ds.Tables[0].DefaultView;
            cbIdCtr.DisplayMemberPath = ds.Tables[0].Columns["Identifiant"].ToString();
            cbIdCtr.SelectedValuePath = ds.Tables[0].Columns["Identifiant"].ToString();
        }
        #endregion

        #region Events
        //CHAMP ONGLET CLIENT
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Êtes-vous sûr de vouloir créer un nouveau client?", "Warning ! Ajout d'un nouveau client", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes))
            {
                MainWindow dialog = new MainWindow();

                try
                {
                    OVClient ovClient = new OVClient();
                    ovClient.NomEntreprise = this.tbNomEts.Text;
                    ovClient.NomResponsable = this.tbNomResp.Text;
                    ovClient.PrenomResponsable = this.tbPrenomResp.Text;
                    ovClient.CiviliteResponsable = this.cbCivResp.Text;
                    ovClient.RueEntreprise = this.tbRueEnt.Text;
                    ovClient.CpEntreprise = int.Parse(this.tbCpEnt.Text);
                    ovClient.VilleEntreprise = tbVilleEnt.Text;
                    ovClient.MailEntreprise = this.tbMailEnt.Text;
                    ovClient.FaxEntreprise = this.tbFaxEnt.Text;
                    ovClient.TelephoneEntreprise = this.tbTelephoneEnt.Text;


                    string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                    string Query = @"INSERT INTO client (NomEntreprise, NomResponsable, PrenomResponsable, CiviliteResponsable, RueEntreprise, CpEntreprise, VilleEntreprise, MailEntreprise, FaxEntreprise, TelephoneEntreprise) values('" + ovClient.NomEntreprise + "','" + ovClient.NomResponsable + "','" + ovClient.PrenomResponsable + "','" + ovClient.CiviliteResponsable + "','" + ovClient.RueEntreprise + "','" + ovClient.CpEntreprise + "','" + ovClient.VilleEntreprise + "','" + ovClient.MailEntreprise + "','" + ovClient.FaxEntreprise + "','" + ovClient.TelephoneEntreprise + "');";


                    MySqlConnection MyConn = new MySqlConnection(connectionString);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyCommand.ExecuteReader();

                    //Vider donnnées apres insertion
                    tbNomEts.Text = string.Empty;
                    tbNomResp.Text = string.Empty;
                    tbPrenomResp.Text = string.Empty;
                    cbCivResp.Text = string.Empty;
                    tbRueEnt.Text = string.Empty;
                    tbCpEnt.Text = string.Empty;
                    tbVilleEnt.Text = string.Empty;
                    tbMailEnt.Text = string.Empty;
                    tbTelephoneEnt.Text = string.Empty;
                    tbFaxEnt.Text = string.Empty;

                    //Rafraichir listBoxClient
                    ListClients.Add(ovClient);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxClient.SelectedItems.Count > 0)
            {
                if ((MessageBox.Show("Êtes-vous sûr de vouloir modifier le client?", "Warning ! Modification d'un client", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes))
                {
                    OVClient ovClient = (OVClient)listBoxClient.SelectedItem;

                    string IdClientUpdate = ovClient.Identifiant.ToString();

                    string NomEts = ovClient.NomEntreprise;
                    string NomResp = ovClient.NomResponsable;
                    string PrenomResp = ovClient.NomResponsable;
                    string CiviliteResp = ovClient.NomResponsable;
                    string RueEts = ovClient.NomResponsable;
                    string CpEts = ovClient.NomResponsable;
                    string VilleEts = ovClient.NomResponsable;
                    string MailEts = ovClient.NomResponsable;
                    string FaxEts = ovClient.NomResponsable;
                    string TelephoneEts = ovClient.NomResponsable;


                    string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                    string Query = @"UPDATE client SET NomEntreprise = '" + tbNomEts.Text + "', NomResponsable = '" + tbNomResp.Text + "', PrenomResponsable = '" + tbPrenomResp.Text + "', CiviliteResponsable = '" + cbCivResp.Text + "', RueEntreprise = '" + tbRueEnt.Text + "', CpEntreprise = '" + tbCpEnt.Text + "', VilleEntreprise = '" + tbVilleEnt.Text + "', MailEntreprise = '" + tbMailEnt.Text + "', FaxEntreprise = '" + tbFaxEnt.Text + "', TelephoneEntreprise = '" + tbTelephoneEnt.Text + "' WHERE Identifiant ='" + IdClientUpdate + "';";


                    MySqlConnection MyConn = new MySqlConnection(connectionString);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyCommand.ExecuteReader();

                    //Vider donnnées apres insertion
                    tbNomEts.Text = string.Empty;
                    tbNomResp.Text = string.Empty;
                    tbPrenomResp.Text = string.Empty;
                    cbCivResp.Text = string.Empty;
                    tbRueEnt.Text = string.Empty;
                    tbCpEnt.Text = string.Empty;
                    tbVilleEnt.Text = string.Empty;
                    tbMailEnt.Text = string.Empty;
                    tbTelephoneEnt.Text = string.Empty;
                    tbFaxEnt.Text = string.Empty;

                    //Rafraichir listBoxClient

                }
            }
            else
            {
                MessageBox.Show("Sélectionner un élément");
            }
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxClient.SelectedItems != null)
            {
                OVClient ovClient = new OVClient();
                ovClient = (OVClient)listBoxClient.SelectedItem;
                string IdClientDelete = ovClient.Identifiant.ToString();

                string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                string Query = @"DELETE FROM client WHERE Identifiant ='" + IdClientDelete + "';";

                MySqlConnection MyConn = new MySqlConnection(connectionString);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();

                //Rafraichir listBoxClient
                ListClients.Remove(ovClient);

                MessageBox.Show("Client Supprimé !");
            }
            else
            {
                MessageBox.Show("Sélectionner un élément");
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.txtFilter.Text != "")
            {
                List<OVClient> listFiltre = new List<OVClient>();

                listFiltre = this.txtFilter.Text != "" ? lstClient.Where(x => (x.NomEntreprise.ToLower().Contains(this.txtFilter.Text.ToLower()))).ToList() : lstClient.ToList();

                this.listBoxClient.ItemsSource = listFiltre;

                if (this.listBoxClient.Items.Count > 0)
                    this.listBoxClient.SelectedIndex = 0;

                this.listBoxClient.ItemsSource = listFiltre;
            }
            if (this.txtFilter.Text == "")
            {
                this.listBoxClient.ItemsSource = lstClient.ToList();
            }
        }

        private void listBoxClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                OVClient ovClient = new OVClient();
                ovClient = (OVClient)listBoxClient.SelectedItem;
                string IDclientChanged = ovClient.Identifiant.ToString();

                string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                string Query = @"SELECT * FROM client WHERE Identifiant = '" + IDclientChanged + "';";


                MySqlConnection MyConn = new MySqlConnection(connectionString);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();

                //Remplir TextBox selon client selectionné
                tbNomEts.Text = ovClient.NomEntreprise;
                tbNomResp.Text = ovClient.NomResponsable;
                tbPrenomResp.Text = ovClient.PrenomResponsable;
                cbCivResp.Text = ovClient.CiviliteResponsable;
                tbRueEnt.Text = ovClient.RueEntreprise;
                tbCpEnt.Text = ovClient.CpEntreprise.ToString();
                tbVilleEnt.Text = ovClient.VilleEntreprise;
                tbMailEnt.Text = ovClient.MailEntreprise;
                tbTelephoneEnt.Text = ovClient.TelephoneEntreprise;
                tbFaxEnt.Text = ovClient.FaxEntreprise;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //CHAMP ONGLET PARTENAIRE DIFFUSION
        private void btnAddPartenaire_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Êtes-vous sûr de vouloir créer un nouveau partenaire de diffusion?", "Warning ! Ajout d'un nouveau partenaire de diffusion", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes))
            {
                MainWindow dialog = new MainWindow();

                try
                {
                    OVDiffuseur ovDiffuseur = new OVDiffuseur();
                    ovDiffuseur.NomEntreprise = this.tbNomEts2.Text;
                    ovDiffuseur.IdentifiantCompte = int.Parse(this.cbPseudo.Text);


                    string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                    string Query = @"INSERT INTO diffuseur (NomEntreprise, IdentifiantCompte) values('" + ovDiffuseur.NomEntreprise + "','" + ovDiffuseur.IdentifiantCompte + "');";


                    MySqlConnection MyConn = new MySqlConnection(connectionString);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyCommand.ExecuteReader();

                    //Vider donnnées apres insertion
                    tbNomEts2.Text = string.Empty;
                    cbPseudo.Text = string.Empty;

                    //Rafraichir listBoxClient
                    ListDiffuseurs.Add(ovDiffuseur);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdatePartenaire_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxPartenaire.SelectedItems.Count > 0)
            {
                if ((MessageBox.Show("Êtes-vous sûr de vouloir modifier le partenaire de diffusion?", "Warning ! Modification d'un partenaire de diffusion", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes))
                {
                    OVDiffuseur ovDiffuseur = (OVDiffuseur)listBoxPartenaire.SelectedItem;

                    string IdPartenaireUpdate = ovDiffuseur.Identifiant.ToString();

                    string NomEts = ovDiffuseur.NomEntreprise;
                    int IdCompte = ovDiffuseur.IdentifiantCompte;

                    string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                    string Query = @"UPDATE diffuseur SET NomEntreprise = '" + tbNomEts2.Text + "', IdentifiantCompte = '" + cbPseudo.Text + "' WHERE Identifiant ='" + IdPartenaireUpdate + "';";


                    MySqlConnection MyConn = new MySqlConnection(connectionString);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyCommand.ExecuteReader();

                    //Vider donnnées apres insertion
                    tbNomEts2.Text = string.Empty;
                    cbPseudo.Text = string.Empty;

                    //Rafraichir listBoxClient

                }
            }
            else
            {
                MessageBox.Show("Sélectionner un élément");
            }
        }

        private void btnDeletePartenaire_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxClient.SelectedItems != null)
            {
                OVDiffuseur ovDiffuseur = new OVDiffuseur();
                ovDiffuseur = (OVDiffuseur)listBoxPartenaire.SelectedItem;
                string IdPartenaireDelete = ovDiffuseur.Identifiant.ToString();

                string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                string Query = @"DELETE FROM diffuseur WHERE Identifiant ='" + IdPartenaireDelete + "';";

                MySqlConnection MyConn = new MySqlConnection(connectionString);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();

                //Rafraichir listBoxClient
                ListDiffuseurs.Remove(ovDiffuseur);

                MessageBox.Show("Partenaire de diffusion Supprimé !");
            }
            else
            {
                MessageBox.Show("Sélectionner un élément");
            }
        }

        private void txtFilter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.txtFilter2.Text != "")
            {
                List<OVDiffuseur> listFiltre = new List<OVDiffuseur>();

                listFiltre = this.txtFilter2.Text != "" ? lstDiffuseur.Where(x => (x.NomEntreprise.ToLower().Contains(this.txtFilter2.Text.ToLower()))).ToList() : lstDiffuseur.ToList();

                this.listBoxPartenaire.ItemsSource = listFiltre;

                if (this.listBoxPartenaire.Items.Count > 0)
                    this.listBoxPartenaire.SelectedIndex = 0;

                this.listBoxPartenaire.ItemsSource = listFiltre;
            }
            if (this.txtFilter2.Text == "")
            {
                this.listBoxPartenaire.ItemsSource = lstDiffuseur.ToList();
            }
        }

        private void listBoxPartenaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                OVDiffuseur ovDiffuseur = new OVDiffuseur();
                ovDiffuseur = (OVDiffuseur)listBoxPartenaire.SelectedItem;
                string IdPartenaireChanged = ovDiffuseur.Identifiant.ToString();

                string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                string Query = @"SELECT * FROM diffuseur WHERE Identifiant = '" + IdPartenaireChanged + "';";


                MySqlConnection MyConn = new MySqlConnection(connectionString);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();

                //Remplir TextBox selon client selectionné
                tbNomEts2.Text = ovDiffuseur.NomEntreprise;
                cbPseudo.Text = ovDiffuseur.IdentifiantCompte.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //CHAMP ONGLET OFFRE CASTING
        private void btnAddOffre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateOffre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteOffre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtFilter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.txtFilter3.Text != "")
            {
                List<OVOffre> listFiltre = new List<OVOffre>();

                listFiltre = this.txtFilter3.Text != "" ? lstOffre.Where(x => (x.Libelle.ToLower().Contains(this.txtFilter3.Text.ToLower()))).ToList() : lstOffre.ToList();

                this.listBoxOffre.ItemsSource = listFiltre;

                if (this.listBoxOffre.Items.Count > 0)
                    this.listBoxOffre.SelectedIndex = 0;

                this.listBoxOffre.ItemsSource = listFiltre;
            }
            if (this.txtFilter3.Text == "")
            {
                this.listBoxOffre.ItemsSource = lstOffre.ToList();
            }
        }

        private void listBoxOffre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                OVOffre ovOffre = new OVOffre();
                ovOffre = (OVOffre)listBoxOffre.SelectedItem;
                string IdOffreChanged = ovOffre.Identifiant.ToString();

                string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                string Query = @"SELECT * FROM offre WHERE Identifiant = '" + IdOffreChanged + "';";


                MySqlConnection MyConn = new MySqlConnection(connectionString);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();

                //Remplir TextBox selon client selectionné
                tbLibelleEts.Text = ovOffre.Libelle;
                tbRef.Text = ovOffre.Reference;
                dpDebutPub.Text = ovOffre.DateDebutPublication.ToString();
                dpFinPub.Text = ovOffre.DateFinPublication.ToString();
                dpDebutCtr.Text = ovOffre.DateDebutContrat.ToString();
                dpFinCtr.Text = ovOffre.DateFinContrat.ToString();
                tbDescPoste.Text = ovOffre.DescriptionPoste;
                tbDescProfil.Text = ovOffre.DescriptionProfil;
                tbNbPoste.Text = ovOffre.NombresPoste.ToString();
                cbIdClt.Text = ovOffre.IdentifiantClient.ToString();
                cbIdMetier.Text = ovOffre.IdentifiantMetier.ToString();
                cbIdCtr.Text = ovOffre.IdentifiantContrat.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //CHAMP COMMUN
        private void btnEmptyTxtbox_Click(object sender, RoutedEventArgs e)
        {
            txtFilter.Text = String.Empty;
            txtFilter2.Text = String.Empty;
            txtFilter3.Text = String.Empty;
        }

        private void btnViderChamp_Click(object sender, RoutedEventArgs e)
        {
            //Vider donnnées clients apres insertion
            tbNomEts.Text = string.Empty;
            tbNomResp.Text = string.Empty;
            tbPrenomResp.Text = string.Empty;
            cbCivResp.Text = string.Empty;
            tbRueEnt.Text = string.Empty;
            tbCpEnt.Text = string.Empty;
            tbVilleEnt.Text = string.Empty;
            tbMailEnt.Text = string.Empty;
            tbTelephoneEnt.Text = string.Empty;
            tbFaxEnt.Text = string.Empty;

            //Vider données partenaires
            tbNomEts2.Text = string.Empty;
            cbPseudo.Text = string.Empty;

            //Vider données offres castings
            tbLibelleEts.Text = string.Empty;
            tbRef.Text = string.Empty;
            dpDebutPub.Text = string.Empty;
            dpFinPub.Text = string.Empty;
            dpDebutCtr.Text = string.Empty;
            dpFinCtr.Text = string.Empty;
            tbDescPoste.Text = string.Empty;
            tbDescProfil.Text = string.Empty;
            tbNbPoste.Text = string.Empty;
            cbIdClt.Text = string.Empty; ;
            cbIdMetier.Text = string.Empty;
            cbIdCtr.Text = string.Empty;
        }
        #endregion
    }
}
