using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backgroundWorkerUSO
{

    public partial class Form1 : Form
    {
        private int contador = 1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.timer1.Start();
            if(this.backgroundWorker1.IsBusy != true)
            {
       
                this.backgroundWorker1.RunWorkerAsync();

            }


        }

        private void btnSaludar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SALUDAAANDOOO");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
      
            Thread.Sleep(10000);
            this.timer1.Stop();
            backgroundWorker1.ReportProgress(100);

            MessageBox.Show((contador-1).ToString());
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso terminado");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            backgroundWorker1.ReportProgress(100-(100/contador));
        }                          
    }
}
