using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls
{
    public partial class PDraw : UserControl
    {
        public PDraw()
        {
            InitializeComponent();
        }
        List<Ball> figureList = new List<Ball>(); // список экземпляров (шаров)
        Random rand = new Random(DateTime.Now.Millisecond);
        
        private void Tick(object sender, EventArgs e)
        {
            // Метод проверки соударения со стенками
            foreach (Ball ball in figureList)
                ball.Trajectory(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Invalidate(); // Перерисовка
        }

        private void Speed(object sender, EventArgs e)
        {
            timer1.Interval = rand.Next(50, 300); ; // Скорость
        }

        private void DrawFigure(object sender, PaintEventArgs e)
        {
            foreach (Ball ball in figureList)
                ball.Draw(e); // Само рисование
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
            int i = 0;
            bool found = false;

            foreach (Ball ball in figureList)
            {
                if (e.X >= ball.GetPosition().X - 15 && e.Y >= ball.GetPosition().Y - 15)
                { }
            }

            figureList.Add(new Ball(rand, e.X, e.Y));
        }
    }
}
