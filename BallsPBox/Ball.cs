using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsPBox
{
    public class Ball
    {
        public PictureBox pb;

        private int dX;
        private int dY;

        public Ball(int x, int y)
        {
            pb = new PictureBox();

            Bitmap b = new Bitmap(100, 100);
            pb.Location = new Point(x, y);
            pb.Size = new Size(40, 40);
            pb.BackColor = Color.Transparent;
            using (Graphics g = Graphics.FromImage(b))
            {
                g.FillEllipse(PickBrush(), 0, 0, 40, 40);
            }         
            pb.Image = b;

            Random rnd = new Random();
            dX = rnd.Next(-20, 20);
            dY = rnd.Next(-20, 20);
        }

        public Ball()
        { }

        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        public void Move(int width, int height)
        {
            int X = pb.Location.X;
            int Y = pb.Location.Y;

            if (X <= (40 / 2))
                dX = -dX;
            if (X >= width - (40 / 2))
                dX = -dX;
            if (Y <= (40 / 2))
                dY = -dY;
            if (Y >= height - (40 / 2))
                dY = -dY;

            X += dX;
            Y += dY;

            pb.Location = new Point(X, Y);
        }
    }
}
