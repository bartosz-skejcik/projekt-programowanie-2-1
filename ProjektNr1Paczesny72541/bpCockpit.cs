using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr1Paczesny72541
{
    public partial class bpCockpit : Form
    {
        public bpCockpit()
        {
            InitializeComponent();
        }

        private void bpLabBtn_Click(object sender, EventArgs e)
        {
            foreach (Form bpForm in Application.OpenForms)
            {
                if (bpForm is bpCockpitLaboratory)
                {
                    this.Hide();
                    bpForm.Show();

                    return;
                }
            }
            
            bpCockpitLaboratory bpNewForm = new bpCockpitLaboratory();
            
            this.Hide();
            bpNewForm.Show();
        }
        
        
        private void bpIndividualBtn_Click(object sender, EventArgs e)
        {
            foreach (Form bpForm in Application.OpenForms)
            {
                if (bpForm is bpCockpitIndividual)
                {
                    this.Hide();
                    bpForm.Show();

                    return;
                }
            }
            
            bpCockpitIndividual bpNewForm = new bpCockpitIndividual();
            
            this.Hide();
            bpNewForm.Show();
        }

        private void bpCockpit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}