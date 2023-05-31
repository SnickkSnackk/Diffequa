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
    public partial class Form1 : Form
    {
        Form2 s = null;
        List<string> steps = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            steps.Clear();
            try
            {
                var equation = InputEqua.Text;

                var expr = MathS.FromString(equation);

                var x0 = double.Parse(textBox1.Text);
                var y0 = double.Parse(textBox2.Text);

                var xi = double.Parse(textBox3.Text);
                var h = double.Parse(textBox4.Text);

                var n = (xi - x0) / h;

                var x = x0;
                var y = y0;

                for (int i = 0; i < n; i++)
                {
                    var nextY = (expr.Substitute("x", x).Substitute("y", y)).EvalNumerical() * h;
                    y = (double)(y + nextY);

                    x += h;

                    OutputEqua.Text = ($"x = {x}, y = {y}");
                    steps.Add(OutputEqua.Text);
                }
                if (s != null) s.Close();
            }
            catch (System.FormatException) { MessageBox.Show("Одно из значений неверно указано!"); }
            catch (AngouriMath.Core.Exceptions.UnhandledParseException) { MessageBox.Show("Уравнение имеет неверный формат!"); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutputEqua_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            s = new Form2(InputEqua.Text, steps);
            s.Show();
        }
    }
}
