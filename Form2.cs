using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngouriMath;

namespace Diffequa
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string equation, List<string> steps) : base()
        {
            InitializeComponent();
            this.Text = equation;
            bindingSource1.DataSource = steps;
            listBox1.DataSource = bindingSource1;
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
