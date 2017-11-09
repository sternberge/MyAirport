using MyAirport.Pim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                    //AttenteBagage();
                    break;
                case PimState.CreationBagage:
                    //CreationBagage();
                    break;
                case PimState.SelectionBagage:
                    //SelectionBagage();
                    break;
                default:
                    //Deconnecter();
                    break;
            }
        }


        public void AffichageBagage()
        {
            this.recherche.Visible = true;
            this.resultat.Visible = true;
            this.bagage.Visible = true;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox2.Text = String.Empty;
            this.textBox5.Text = String.Empty;
            this.textBox6.Text = String.Empty;
        }

        public void CreationBagage()
        {
            this.recherche.Visible = true;
            this.resultat.Visible = true;
            this.bagage.Visible = true;
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
            this.textBox6.Enabled = true;
            this.textBox7.Enabled = true;
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
                var bagages = monBagage;
                this.textBox2.Text = bagages.Compagnie.ToString();
                this.textBox2.Enabled = false;
                this.textBox5.Text = bagages.DateVol.ToString();
                this.textBox5.Enabled = false;
                this.textBox6.Text = bagages.Itineraire.ToString();
                this.textBox6.Enabled = false;
                //this.textBox7.Text = bagag
                if (bagages.EnContinuation)
                {
                    this.continuation.Checked = true;
                    this.continuation.Enabled = false;
                }
            }
                else
                {
                    MessageBox.Show("Code Iata incorrect");                   
                    this.AffichageBagage();
                    //this.textBox7.Text = bagag
                }
            }
            
            catch(Exception exception)
            {
                MessageBox.Show("Error occurs");
            }
        }
    }
}
