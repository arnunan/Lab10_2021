using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Level1 : Form
    {

        int Global = 0;
        static Point[] main = new Point[40];
        static Point[] c = new Point[4];
        static int pressedTarget;
        static int pointcounter = 0;
        int mainscore = 0;
        static TextBox stat = new TextBox();

        public Level1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);

            UpdateStyles();
            Cursor.Show();

            main = GameLodic.MakeCoords(1);
            c = GameLodic.NextPoint(main, pointcounter, 1);
            pointcounter++;
            var mainscore = new TextBox();
        }

        public void Timer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(GameLodic.CountdownCounter.ToString(), GameLodic.Font, GameLodic.Brush, new Rectangle(ClientRectangle.Width / 2, ClientRectangle.Height / 2 - 150, 1000, 1000));
        }

        public void Dop(object sender, PaintEventArgs e)
        {
            var rec = new PictureBox();
            if (pressedTarget < 4)
            {
                rec.BackColor = Color.White;
                rec.Size = new Size(140, 200);
                rec.Location = new Point(c[pressedTarget].X, c[pressedTarget].Y);
                Controls.Add(rec);
                mainscore += 100;
            }
            pressedTarget = 15;
        }

        private void MenuClick(object sender, EventArgs e)
        {
            Hide();
            Menu newForm = new Menu();
            newForm.Show();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Mouse(object sender, MouseEventArgs e)
        {
            var posiiton = PointToClient(Cursor.Position);
            for (int i = 0; i < 4; i++)
            {
                if ((posiiton.X >= c[i].X && posiiton.X <= c[i].X + 140) && ((posiiton.Y >= c[i].Y && posiiton.Y <= c[i].Y + 200)))
                {
                    pressedTarget = i;
                    Paint += new PaintEventHandler(Dop);
                }
            }
        }

        private void FpsTimer(object sender, EventArgs e)
        {
            Refresh();
        }

        public void MakeTarget(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            for (int i = 0; i < 4; i++)
            {
                g.DrawImage(GameLodic.Target, new Rectangle(c[i].X, c[i].Y, 140, 200));
            }

        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            Global++;

            if (GameLodic.CountdownCounter > 2)
            {
                Paint += new PaintEventHandler(Timer);
            }
            else if (GameLodic.CountdownCounter > -1)
            {
                Paint -= new PaintEventHandler(Timer);
            }
            GameLodic.CountdownCounter--;

            if (Global % 4 == 0 && pointcounter <= 10 && Global > 4)
            {
                Controls.Clear();
                Paint += new PaintEventHandler(MakeTarget);
                c = GameLodic.NextPoint(main, pointcounter, 1);
                pointcounter++;
            }
            else if (pointcounter == 11 && Global > 50)
            {
                stat = GameLodic.MakeStat(stat, mainscore);
                Controls.Add(stat);
                pointcounter++;
                var nm = new PictureBox();
                nm.BackColor = Color.White;
                nm.Size = new Size(2560, 1440);
                nm.Location = new Point(0, 0);
                Controls.Add(nm);
            }
        }

        private void Level1_Deactivate(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
