using System.Windows.Forms;

namespace ProjektNr1Paczesny72541
{
    public partial class bpCockpitIndividual : Form
    {
        public bpCockpitIndividual()
        {
            InitializeComponent();
        }

        private void bpCockpitIndividual_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show("Czy napewno chcesz zamknąć Projekt Indywidualny?", "Zamknij", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (DialogResult == DialogResult.Yes)
            {
                e.Cancel = false;
                
                bpCockpit bpMainForm = new bpCockpit();
                 
                this.Hide();
                bpMainForm.Show();
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}