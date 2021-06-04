using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Menu : Form
    {
        public Bitmap marker = Resource1.marker;
        public Bitmap logo = Resource1.logo2;
        public Menu()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);

            UpdateStyles();
            Cursor.Hide();
        }

        private void Form_Paint1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var posiiton = PointToClient(Cursor.Position);

            var size = PointF.Empty;
            size.X = 150;
            size.Y = 150;
            var font = new Font("Haettenschweiler", 32, FontStyle.Regular);
            var brush = new SolidBrush(Color.Black);

            g.DrawImage(logo, new Rectangle(ClientRectangle.Width / 2 - 435, ClientRectangle.Height / 4 - 154, 869, 308));
            g.DrawImage(marker, new Rectangle(posiiton.X - 2, posiiton.Y - 2, 7, 7));
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Refresh();
        }

        public void ClearWindow(Graphics g)
        {
            var color = Color.FromArgb(255, 192, 255, 255);
            g.Clear(color);
        }

        private void LevelClick(object sender, EventArgs e)
        {
            int tag = Convert.ToInt16(((Button)sender).Tag);
            switch (tag)
            {
                case 1:
                    {
                        Hide();
                        var newForm = new Level1();
                        newForm.Show();
                        return;
                    }
                case 2:
                    {
                        Hide();
                        var newForm = new Level2();
                        newForm.Show();
                        return;
                    }
                case 3:
                    {
                        Hide();
                        var newForm = new Level3();
                        newForm.Show();
                        return;
                    }
                case 4:
                    {
                        Hide();
                        var newForm = new Level4();
                        newForm.Show();
                        return;
                    }
            }
            Hide();

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
