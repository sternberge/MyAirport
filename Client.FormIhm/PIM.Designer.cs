using System;

namespace Client.FormIhm
{
    partial class PIM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.commandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réinitialiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateBagage = new System.Windows.Forms.ToolStripMenuItem();
            this.FindBagage = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.recherche = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.resultat = new System.Windows.Forms.GroupBox();
            this.bagage = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Creer = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.rush = new System.Windows.Forms.CheckBox();
            this.continuation = new System.Windows.Forms.CheckBox();
            this.classe = new System.Windows.Forms.Label();
            this.itineraire = new System.Windows.Forms.Label();
            this.vol = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.jour = new System.Windows.Forms.Label();
            this.ligne = new System.Windows.Forms.Label();
            this.compagnie = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.recherche.SuspendLayout();
            this.resultat.SuspendLayout();
            this.bagage.SuspendLayout();
            this.vol.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandesToolStripMenuItem,
            this.etatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // commandesToolStripMenuItem
            // 
            this.commandesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.réinitialiserToolStripMenuItem,
            this.déconnecterToolStripMenuItem});
            this.commandesToolStripMenuItem.Name = "commandesToolStripMenuItem";
            this.commandesToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.commandesToolStripMenuItem.Text = "Commandes";
            // 
            // réinitialiserToolStripMenuItem
            // 
            this.réinitialiserToolStripMenuItem.Name = "réinitialiserToolStripMenuItem";
            this.réinitialiserToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.réinitialiserToolStripMenuItem.Text = "Réinitialiser";
            this.réinitialiserToolStripMenuItem.Click += new System.EventHandler(this.réinitialiserToolStripMenuItem_Click);
            // 
            // déconnecterToolStripMenuItem
            // 
            this.déconnecterToolStripMenuItem.Name = "déconnecterToolStripMenuItem";
            this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.déconnecterToolStripMenuItem.Text = "Déconnecter";
            this.déconnecterToolStripMenuItem.Click += new System.EventHandler(this.déconnecterToolStripMenuItem_Click);
            // 
            // etatToolStripMenuItem
            // 
            this.etatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateBagage,
            this.FindBagage});
            this.etatToolStripMenuItem.Name = "etatToolStripMenuItem";
            this.etatToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.etatToolStripMenuItem.Text = "Etat";
            // 
            // CreateBagage
            // 
            this.CreateBagage.Name = "CreateBagage";
            this.CreateBagage.Size = new System.Drawing.Size(178, 26);
            this.CreateBagage.Tag = "";
            this.CreateBagage.Text = "CreateBagage";
            this.CreateBagage.Click += new System.EventHandler(this.CreateBagage_Click);
            // 
            // FindBagage
            // 
            this.FindBagage.Name = "FindBagage";
            this.FindBagage.Size = new System.Drawing.Size(178, 26);
            this.FindBagage.Text = "FindBagage";
            this.FindBagage.Click += new System.EventHandler(this.FindBagage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(300, 20);
            this.toolStripStatusLabel1.Text = "Messages";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(150, 20);
            this.toolStripStatusLabel2.Text = "Etat";
            // 
            // recherche
            // 
            this.recherche.Controls.Add(this.button1);
            this.recherche.Controls.Add(this.label1);
            this.recherche.Controls.Add(this.textBox1);
            this.recherche.Dock = System.Windows.Forms.DockStyle.Top;
            this.recherche.Location = new System.Drawing.Point(0, 28);
            this.recherche.Name = "recherche";
            this.recherche.Size = new System.Drawing.Size(866, 100);
            this.recherche.TabIndex = 2;
            this.recherche.TabStop = false;
            this.recherche.Text = "Recherche";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Rechercher";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "CodeIata";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.Location = new System.Drawing.Point(111, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(537, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "005412457800";
            // 
            // resultat
            // 
            this.resultat.Controls.Add(this.bagage);
            this.resultat.Controls.Add(this.vol);
            this.resultat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultat.Location = new System.Drawing.Point(0, 128);
            this.resultat.Name = "resultat";
            this.resultat.Size = new System.Drawing.Size(866, 426);
            this.resultat.TabIndex = 3;
            this.resultat.TabStop = false;
            this.resultat.Text = "Résultat";
            // 
            // bagage
            // 
            this.bagage.Controls.Add(this.checkBox1);
            this.bagage.Controls.Add(this.Creer);
            this.bagage.Controls.Add(this.textBox7);
            this.bagage.Controls.Add(this.textBox6);
            this.bagage.Controls.Add(this.rush);
            this.bagage.Controls.Add(this.continuation);
            this.bagage.Controls.Add(this.classe);
            this.bagage.Controls.Add(this.itineraire);
            this.bagage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bagage.Location = new System.Drawing.Point(427, 18);
            this.bagage.Name = "bagage";
            this.bagage.Size = new System.Drawing.Size(436, 405);
            this.bagage.TabIndex = 1;
            this.bagage.TabStop = false;
            this.bagage.Text = "Bagage";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(158, 239);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Prioritaire";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Creer
            // 
            this.Creer.Location = new System.Drawing.Point(266, 259);
            this.Creer.Name = "Creer";
            this.Creer.Size = new System.Drawing.Size(143, 54);
            this.Creer.TabIndex = 6;
            this.Creer.Text = "Créer";
            this.Creer.UseVisualStyleBackColor = true;
            this.Creer.Click += new System.EventHandler(this.Creer_Click);
            // 
            // textBox7
            // 
            this.textBox7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox7.Location = new System.Drawing.Point(158, 96);
            this.textBox7.MaxLength = 1;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(47, 22);
            this.textBox7.TabIndex = 5;
            this.textBox7.Text = "1";
            // 
            // textBox6
            // 
            this.textBox6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox6.Location = new System.Drawing.Point(158, 38);
            this.textBox6.MaxLength = 3;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(47, 22);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "BKK";
            // 
            // rush
            // 
            this.rush.AutoSize = true;
            this.rush.Location = new System.Drawing.Point(158, 192);
            this.rush.Name = "rush";
            this.rush.Size = new System.Drawing.Size(63, 21);
            this.rush.TabIndex = 3;
            this.rush.Text = "Rush";
            this.rush.UseVisualStyleBackColor = true;
            // 
            // continuation
            // 
            this.continuation.AutoSize = true;
            this.continuation.Location = new System.Drawing.Point(158, 143);
            this.continuation.Name = "continuation";
            this.continuation.Size = new System.Drawing.Size(109, 21);
            this.continuation.TabIndex = 2;
            this.continuation.Text = "Continuation";
            this.continuation.UseVisualStyleBackColor = true;
            // 
            // classe
            // 
            this.classe.AutoSize = true;
            this.classe.Location = new System.Drawing.Point(21, 96);
            this.classe.Name = "classe";
            this.classe.Size = new System.Drawing.Size(102, 17);
            this.classe.TabIndex = 1;
            this.classe.Text = "Classe bagage";
            // 
            // itineraire
            // 
            this.itineraire.AutoSize = true;
            this.itineraire.Location = new System.Drawing.Point(21, 44);
            this.itineraire.Name = "itineraire";
            this.itineraire.Size = new System.Drawing.Size(63, 17);
            this.itineraire.TabIndex = 0;
            this.itineraire.Text = "Itinéraire";
            // 
            // vol
            // 
            this.vol.Controls.Add(this.label2);
            this.vol.Controls.Add(this.listBox1);
            this.vol.Controls.Add(this.textBox5);
            this.vol.Controls.Add(this.textBox3);
            this.vol.Controls.Add(this.textBox2);
            this.vol.Controls.Add(this.jour);
            this.vol.Controls.Add(this.ligne);
            this.vol.Controls.Add(this.compagnie);
            this.vol.Dock = System.Windows.Forms.DockStyle.Left;
            this.vol.Location = new System.Drawing.Point(3, 18);
            this.vol.Name = "vol";
            this.vol.Size = new System.Drawing.Size(424, 405);
            this.vol.TabIndex = 0;
            this.vol.TabStop = false;
            this.vol.Text = "Vol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "(yyyy-MM-dd HH:mm:ss)";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 239);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(418, 148);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // textBox5
            // 
            this.textBox5.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox5.Location = new System.Drawing.Point(178, 159);
            this.textBox5.MaxLength = 19;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(158, 22);
            this.textBox5.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox3.Location = new System.Drawing.Point(178, 90);
            this.textBox3.MaxLength = 5;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(69, 22);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "5624";
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox2.Location = new System.Drawing.Point(178, 38);
            this.textBox2.MaxLength = 20;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "LH";
            // 
            // jour
            // 
            this.jour.AutoSize = true;
            this.jour.Location = new System.Drawing.Point(36, 159);
            this.jour.Name = "jour";
            this.jour.Size = new System.Drawing.Size(122, 17);
            this.jour.TabIndex = 2;
            this.jour.Text = "Jour d\'exploitation";
            // 
            // ligne
            // 
            this.ligne.AutoSize = true;
            this.ligne.Location = new System.Drawing.Point(36, 96);
            this.ligne.Name = "ligne";
            this.ligne.Size = new System.Drawing.Size(43, 17);
            this.ligne.TabIndex = 1;
            this.ligne.Text = "Ligne";
            // 
            // compagnie
            // 
            this.compagnie.AutoSize = true;
            this.compagnie.Location = new System.Drawing.Point(33, 44);
            this.compagnie.Name = "compagnie";
            this.compagnie.Size = new System.Drawing.Size(79, 17);
            this.compagnie.TabIndex = 0;
            this.compagnie.Text = "Compagnie";
            // 
            // PIM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 579);
            this.Controls.Add(this.resultat);
            this.Controls.Add(this.recherche);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PIM";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.PIM_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.recherche.ResumeLayout(false);
            this.recherche.PerformLayout();
            this.resultat.ResumeLayout(false);
            this.bagage.ResumeLayout(false);
            this.bagage.PerformLayout();
            this.vol.ResumeLayout(false);
            this.vol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem commandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem réinitialiserToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.GroupBox recherche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox resultat;
        private System.Windows.Forms.GroupBox bagage;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox rush;
        private System.Windows.Forms.CheckBox continuation;
        private System.Windows.Forms.Label classe;
        private System.Windows.Forms.Label itineraire;
        private System.Windows.Forms.GroupBox vol;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label jour;
        private System.Windows.Forms.Label ligne;
        private System.Windows.Forms.Label compagnie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem etatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateBagage;
        private System.Windows.Forms.ToolStripMenuItem FindBagage;
        private System.Windows.Forms.ToolStripMenuItem déconnecterToolStripMenuItem;
        private System.Windows.Forms.Button Creer;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
    }
}