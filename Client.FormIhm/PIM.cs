using MyAirport.Pim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.FormIhm
{
    public partial class PIM : Form
    {
        ServiceReferencePim.ServicePimClient proxy = null;

        private PimState state = PimState.Deconnecter;
        private PimState State
        {
            get { return this.state; }
            set { OnPimStateChanged(value); }
        }

        public PIM()
        {
            InitializeComponent();
            this.PimStateChanged += PIM_PimStateChanged;
            proxy = new ServiceReferencePim.ServicePimClient();
            
        }

        void PIM_PimStateChanged(object sender, PimState state)
        {
            switch (State)
            {
                case PimState.AffichageBagage:
                    AffichageBagage();
                    break;
                case PimState.AttenteBagage:
                    AttenteBagage();
                    break;
                case PimState.CreationBagage:
                    CreationBagage();
                    break;
                case PimState.SelectionBagage:
                    SelectionBagage();
                    break;
                default:
                    Deconnecter();
                    break;
            }
        }

        public void AttenteBagage()
        {
            this.recherche.Visible = true;
            this.resultat.Visible = true;
            this.bagage.Visible = true;
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox2.Text = String.Empty;
            this.textBox5.Text = String.Empty;
            this.textBox6.Text = String.Empty;
            this.Creer.Enabled = false;

        }


        public void AffichageBagage()
        {
            this.recherche.Visible = false;
            this.resultat.Visible = true;
            this.bagage.Visible = true;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox2.Text = String.Empty;
            this.textBox5.Text = String.Empty;
            this.textBox6.Text = String.Empty;
            this.Creer.Enabled = false;
            this.checkBox1.Enabled = false;
            this.rush.Enabled = false;
            this.continuation.Enabled = false;
        }

        public void Deconnecter()
        {
            this.recherche.Visible = false;
            this.resultat.Visible = false;
            this.bagage.Visible = false;
        }

        public void SelectionBagage()
        {
            this.button1.Enabled = true;
            this.textBox1.Enabled = true;
            this.recherche.Visible = true;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox2.Text = String.Empty;
            this.textBox5.Text = String.Empty;
            this.textBox6.Text = String.Empty;
            this.continuation.Enabled = false;
            this.rush.Enabled = false;
            this.button1.Enabled = true;
            this.Creer.Enabled = false;

        }

        public void CreationBagage()
        {
            this.recherche.Visible = true;
            this.resultat.Visible = true;
            this.bagage.Visible = true;
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            
            this.textBox5.Enabled = true;
            this.textBox6.Enabled = true;
            this.textBox7.Enabled = true;
            this.continuation.Enabled = true;
            this.rush.Enabled = true;
            this.button1.Enabled = false;
            this.Creer.Enabled = true;
        }


        private void PIM_Load(object sender, EventArgs e)
        {
            
        }

        public event PimStateEventHandler PimStateChanged;
        public delegate void PimStateEventHandler(object sender, PimState state);

        private void OnPimStateChanged(PimState newState)
        {
            if (newState != this.state)
            {
                this.state = newState;
                if (this.PimStateChanged != null)
                {
                    PimStateChanged(this, this.state);
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Client.FormIhm.ServiceReferencePim.BagageDefinition monBagage = proxy.GetBagageByCodeIataAsync(this.textBox1.Text).Result;

                if (monBagage != null)
                {
                    this.OnPimStateChanged(PimState.AffichageBagage);
                    var bagages = monBagage;
                    this.textBox2.Text = bagages.Compagnie.ToString();
                    this.textBox2.Enabled = false;
                    this.textBox5.Text = bagages.DateVol.ToString();
                    this.textBox5.Enabled = false;
                    this.textBox6.Text = bagages.Itineraire.ToString();
                    this.textBox6.Enabled = false;
                    if (bagages.EnContinuation)
                    {
                        this.continuation.Checked = true;
                        this.continuation.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Code Iata incorrect");
                    this.OnPimStateChanged(PimState.SelectionBagage);                   
                }
            }
            catch (AggregateException exception)
            {
                MessageBox.Show("Serveur non accesible");
            }

            catch (CommunicationException exp)
            {
                MessageBox.Show("Probleme de communication entre le client et le serveur");
            }

            catch (Exception exception)
            {
                MessageBox.Show("Une erreur s'est produite dans le traitement de votre demande : "+exception.GetType().ToString());
            }
        }

       

        private void réinitialiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.SelectionBagage);
            //this.SelectionBagage();
        }

        private void CreateBagage_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.CreationBagage);
            //this.CreationBagage();
        }

        private void FindBagage_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.SelectionBagage);
            //this.SelectionBagage();
        }

        private void déconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.Deconnecter);
        }

        private void Creer_Click(object sender, EventArgs e)
        {
            Client.FormIhm.ServiceReferencePim.BagageDefinition bagage = new Client.FormIhm.ServiceReferencePim.BagageDefinition();
            bagage.Compagnie = this.textBox2.Text;
            bagage.DateVol = DateTime.ParseExact(this.textBox5.Text, "yyyy-MM-dd hh:mm:ss",
                                     System.Globalization.CultureInfo.InvariantCulture); ;
            bagage.Itineraire = this.textBox6.Text;
            bagage.Ligne = this.textBox3.Text;
            bagage.CodeIata = this.textBox1.Text;

            if (this.checkBox1.Checked)
                bagage.Prioritaire = true;
            else
                bagage.Prioritaire = false;

            if (this.rush.Checked)
                bagage.Rush = true;
            else bagage.Rush = false;

            if (this.continuation.Checked)
                bagage.EnContinuation = true;
            else bagage.EnContinuation = false;
            int idBagage = proxy.CreateBagage(bagage);
        }
    }
}
