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
        }

        void PIM_PimStateChanged(object sender, PimState state)
        {
            switch (State)
            {
                case PimState.AffichageBagage:
                    //AffichageBagage();
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
            this.recherche.Visible = false;
            this.resultat.Visible = false;
            this.bagage.Visible = false;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Vol_Enter(object sender, EventArgs e)
        {

        }

        private void Bagage_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var bagages = Factory.Model.GetBagage(Convert.ToInt32(textBox1.Text));
            if (bagages != null)
            {
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
                    MessageBox.Show("Code Id incorrect");
                    this.textBox2.Text = String.Empty;
                    this.textBox2.Enabled = true;
                    this.textBox5.Text = String.Empty;
                    this.textBox5.Enabled = true;
                    this.textBox6.Text = String.Empty;
                    this.textBox6.Enabled = true;
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
