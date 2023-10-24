using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal_Stars
{
    public partial class Form1 : Form
    {
        private const double it = 1280;//количество итераций для отрисовки звезды
        private const double r = 0.35;//коэффициент масштабирования
        private const double l = 300;// начальная длина линии
        private const double da = 4 * Math.PI / 5; //угол поворота между ветвями звезды(P.S. изменив 4 на 2 или 3 - будет фрактал много-ка)
        private const double v = 4;//число ветвей звезды
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)//рисование фрактала Звезды
        {
            base.OnPaint(e);

            double a = 0;
            double x = 280, y = 330;
            double xn, yn;

            for (int i = 0; i < it; i++)//цикл до конца кол-ва итераций для отрисовки звезды
                                        //l-длина линии звезды
            {
                xn = x + Math.Sin(a) * l * Mn(i);//высчитываем новые координаты конца линии по x и y каждый раз
                yn = y - Math.Cos(a) * l * Mn(i);

                e.Graphics.DrawLine(Pens.Blue, (float)x, (float)y, (float)xn, (float)yn);//рисуем линию от текущей координаты x и y до новой
                                                                                         //координаты
                                                                                         //и после обновляем координаты
                x = xn;
                y = yn;
                a += da;
            }
        }

        private double Mn(int nn)//высчитывание коэфициента масштабирования
        {
            if (nn % (v * v * v * v) == 0) return 1;
            if (nn % (v * v * v) == 0) return r;
            if (nn % (v * v) == 0) return r * r;
            if (nn % v == 0) return r * r * r;
            return r * r * r * r;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
