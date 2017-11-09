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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ServiceHost host = null;
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(MyAirport.Pim.Service.ServicePim));
        }
    }

}
