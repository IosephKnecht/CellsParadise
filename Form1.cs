using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CellsParadise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Epoch epoch = Epoch.Incstance(10, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Epoch.Incstance().CalculEpoch();
        }
    }
}
