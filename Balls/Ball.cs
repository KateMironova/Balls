using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Balls
{
    public class Ball
    {
        private int R = 30;
        // Координаты
        private int X;
        private int Y;
        // Путь за 1 тик таймера
        private int dX;
        private int dY;
        private Color color;

        public Point GetPosition()
        {
            return new Point(X, Y);
        }
        // Заполнение данных о шаре 
        public Ball(Random rand, int x, int y)
        {      
            X = x; // Координаты центра
            Y = y;
            dX = rand.Next(1, 10); // Путь за один tick таймера (в пикселях)
            dY = rand.Next(1, 10);
            color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255));
        }
        public void Draw(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(color);
            Graphics rg = e.Graphics;
            rg.FillEllipse(brush, X - (R / 2), Y - (R / 2), R, R);
        }

        //рассчет траектории
        public void Trajectory(int width, int height)
        {
            if (X <= 0 || X >= width)
                dX = -dX; 
            if (Y <= 0 || Y >= height)
                dY = -dY;
            // прибавляем к текущей координате изменение пути
            X += dX;
            Y += dY;
        }
    }
}
