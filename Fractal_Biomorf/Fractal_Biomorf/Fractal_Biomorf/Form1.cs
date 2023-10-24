using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal_Biomorf
{
    public partial class Form1 : Form
    {
        private const int iter = 70000;
        private const double a = 2.8;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Random rand = new Random();
            double x = 0.0;
            double y = 0.0;
            double t;

            for (int k = 0; k < iter; k++)
            {
                double p = rand.NextDouble();
                t = x;

                if (p <= 0.5)
                {
                    x = -y;
                    y = t;
                }
                else
                {
                    x = 1 + (a * (x - 1)) / (Math.Pow(x - 1, 2) + Math.Pow(y, 2) + 1);
                    y = a * y / (Math.Pow(t - 1, 2) + Math.Pow(y, 2) + 1);
                }

                e.Graphics.FillRectangle(Brushes.Black, (int)(ClientSize.Width / 2 + 200 * x), (int)(ClientSize.Height / 2 - 200 * y), 1, 1);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
       
            private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
