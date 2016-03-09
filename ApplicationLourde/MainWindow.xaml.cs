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

        private ObservableCollection<OVClient> lstClient;

       // private List<OVClient> lstClientSearch = new List<OVClient>();

        public ObservableCollection<OVClient> ListClients
        {
            get { return lstClient; }
            set { lstClient = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            connect.openConnect();

            AlimenterListeClient();

            this.DataContext = this;
        }

        private void AlimenterListeClient()
        {
            lstClient = new ObservableCollection<OVClient>();
            String loadClient = "SELECT Identifiant, NomEntreprise, NomResponsable, PrenomResponsable, CiviliteResponsable, RueEntreprise, CpEntreprise, VilleEntreprise, MailEntreprise, FaxEntreprise, TelephoneEntreprise FROM client";
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

        #region Events
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
                //if ((MessageBox.Show("Êtes-vous sûr de vouloir modifier le client?", "Warning ! Modification d'un client", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes))
                //{
                //    OVClient ovClient = (OVClient)listBoxClient.SelectedItem;

                //    string IDclientUpdate = ovClient.Identifiant.ToString();
                //    string NomEts = ovClient.NomEntreprise;
                //    string NomResp = ovClient.NomResponsable;
                //    string PrenomResp = ovClient.NomResponsable;
                //    string CiviliteResp = ovClient.NomResponsable;
                //    string RueEts = ovClient.NomResponsable;
                //    string CpEts = ovClient.NomResponsable;
                //    string VilleEts = ovClient.NomResponsable;
                //    string MailEts = ovClient.NomResponsable;
                //    string FaxEts = ovClient.NomResponsable; ;
                //    string TelephoneEts = ovClient.NomResponsable; ;


                //    string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                //    string Query = @"UPDATE client SET '" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"','" + +"' WHERE Identifiant ='" + IDclientUpdate + "';";


                //    MySqlConnection MyConn = new MySqlConnection(connectionString);
                //    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                //    MySqlDataReader MyReader;
                //    MyConn.Open();
                //    MyReader = MyCommand.ExecuteReader();

                //    //Vider donnnées apres insertion
                //    tbNomEts.Text = string.Empty;
                //    tbNomResp.Text = string.Empty;
                //    tbPrenomResp.Text = string.Empty;
                //    cbCivResp.Text = string.Empty;
                //    tbRueEnt.Text = string.Empty;
                //    tbCpEnt.Text = string.Empty;
                //    tbVilleEnt.Text = string.Empty;
                //    tbMailEnt.Text = string.Empty;
                //    tbTelephoneEnt.Text = string.Empty;
                //    tbFaxEnt.Text = string.Empty;
                //}
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
                string IDclientDelete = ovClient.Identifiant.ToString();

                string connectionString = "SERVER=localhost" + ";" + "DATABASE=megacastingv2" + ";" + "UID=root" + ";" + "PASSWORD=" + ";";
                string Query = @"DELETE FROM client WHERE Identifiant ='" + IDclientDelete + "';";

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

        private void btnEmptyTxtbox_Click(object sender, RoutedEventArgs e)
        {
            txtFilter.Text = String.Empty;
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

        private void btnViderChamp_Click(object sender, RoutedEventArgs e)
        {
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
        }
        #endregion

        
    }
}
