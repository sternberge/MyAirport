﻿using MyAirport.Pim.Models;
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
using Client.FormIhm.ServiceReferencePim;

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

        
        /// <summary>
        /// Recherche bagage via code Iata à la suite du clic sur le bouton de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BagageDefinition monBagage = proxy.GetBagageByCodeIata(this.textBox1.Text);
                if (monBagage != null)
                {
                    showBagage(monBagage);
                }
            }
            catch (AggregateException)
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("Serveur non disponible");
            }

            catch(EndpointNotFoundException)
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("WebService non disponible");
            }

            catch (FaultException<MultipleBagageFault> excp)
            {
                List <BagageDefinition> Bagages = new List<BagageDefinition>(excp.Detail.ListBagages);
                this.listBox1.Items.Clear();
                foreach (BagageDefinition i in Bagages)
                {
                    this.listBox1.Items.Add(i.IdBagage+"\n");
                }              
            }

            catch (FaultException excp)
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("Une erreur s'est produite dans le traitement de votre demande");
                this.listBox1.Items.Add("\nCode: " + excp.Code.Name);
                this.listBox1.Items.Add("\nReason: " + excp.Reason);
            }
        }



        private void réinitialiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.SelectionBagage);
        }

        private void CreateBagage_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.CreationBagage);
        }

        private void FindBagage_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.SelectionBagage);
        }

        private void déconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnPimStateChanged(PimState.Deconnecter);
        }

        /// <summary>
        /// Creation d'un bagage à la suite d'un clic sur le bouton de creation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            try
            {
                int idBagage = proxy.CreateBagage(bagage);
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("Votre bagage a été crée");
                this.OnPimStateChanged(PimState.SelectionBagage);
            }
            // permet de catch les exception coté client
            catch (FaultException excp)
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add("Une erreur s'est produite dans le traitement de votre demande");
                this.listBox1.Items.Add("\nCode: " + excp.Code.Name);
                this.listBox1.Items.Add("\nReason: " + excp.Reason);
            }

        }
        
        // Affiche le bagage après sa sélection dans la liste box
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                BagageDefinition monBagage=proxy.GetBagageById(int.Parse(listBox1.SelectedItem.ToString()));
                showBagage(monBagage);
            }
        }

        /// <summary>
        /// Affiche le bagage passé en parametre de la methode
        /// </summary>
        /// <param name="monBagage"></param>
        public void showBagage(BagageDefinition monBagage)
        {
            this.OnPimStateChanged(PimState.AffichageBagage);
            var bagages = monBagage;
            this.textBox2.Text = bagages.Compagnie.ToString();
            this.textBox2.Enabled = false;
            this.textBox3.Text = bagages.Ligne.ToString();
            this.textBox3.Enabled = false;
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
    }
}
