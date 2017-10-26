using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BallsPBox
{
    public partial class PDraw : UserControl
    {
        Thread myThread;
        public PDraw()
        {
            InitializeComponent();

            myThread = new Thread(new ThreadStart(MoveBalls));
            myThread.Start();
        }
        private void MoveBalls()
        {
            while (true)
            {
                Thread.Sleep(40);
                foreach (Control c in pictureBox1.Controls)
                {
                    PBall p = (PBall)c;
                    p.MoveBall();
                }
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Controls.Add(new PBall(e.X, e.Y));
        }

    }
}
