using SaveEarth.MainClasses;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaveEarth.Views
{
    public partial class LevelSelectionControl : UserControl
    {
        private MainForm Form;
        private Timer MainTimer = new Timer { Interval = 100 };
        private Image background = Image.FromFile("../../image/Menu/Background/backgroundSpace.png");
        private Image easy = Image.FromFile("../../image/Menu/Buttons/Easy.png");
        private Image easyPress = Image.FromFile("../../image/Menu/Buttons/EasyPress.png");
        private Image normal = Image.FromFile("../../image/Menu/Buttons/Normal.png");
        private Image normalPress = Image.FromFile("../../image/Menu/Buttons/NormalPress.png");
        private Image hard = Image.FromFile("../../image/Menu/Buttons/Hard.png");
        private Image hardPress = Image.FromFile("../../image/Menu/Buttons/HardPress.png");
        private Image back = Image.FromFile("../../image/Menu/Buttons/Back.png");
        private Image backPress = Image.FromFile("../../image/Menu/Buttons/BackPress.png");
        private Image select = Image.FromFile("../../image/Menu/Buttons/Select.png");
        private Image easyHelpDesk = Image.FromFile("../../image/Menu/Buttons/EasyHelpDesk.png");
        private Image normalHelpDesk = Image.FromFile("../../image/Menu/Buttons/NormalHelpDesk.png");
        private Image hardHelpDesk = Image.FromFile("../../image/Menu/Buttons/HardHelpDesk.png");

        private bool EasyButtonPress = false;
        private bool NormalButtonPress = false;
        private bool HardButtonPress = false;
        private bool BackButtonPress = false;


        protected override void OnLoad(EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public LevelSelectionControl(MainForm form)
        {

            InitializeComponent();
            this.BackColor = Color.Black;
            Form = form;
            // ClientSize = new Size(Form.Width, Form.Height);
            ClientSize = Form.Size;
            this.AutoScaleMode = AutoScaleMode.Dpi;

            MainTimer.Tick += MainTimerTick;
            MainTimer.Start();
        }

        private void MainTimerTick(object sender, EventArgs e)
        {
            Invalidate();
            Update();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, ClientRectangle);
            e.Graphics.InterpolationMode = InterpolationMode.Low;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Draw(e.Graphics);
        }

        private void Draw(Graphics g)
        {

            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);
            CheckMousePressing();

            g.DrawImage(background, -background.Width / 2 - 200, -background.Height / 2 - 100);
            g.DrawImage(select, -select.Width / 2, -select.Height / 2 - 300);

            if (EasyButtonPress)
            {
                g.DrawImage(easyPress, -easyPress.Width / 2, -easyPress.Height / 2 - 100);
                g.DrawImage(easyHelpDesk, -easyHelpDesk.Width / 2 + 400, -easyHelpDesk.Height / 2);
            }
            else
                g.DrawImage(easy, -easy.Width / 2, -easy.Height / 2 - 100);

            if (NormalButtonPress)
            {
                g.DrawImage(normalPress, -normalPress.Width / 2, -normalPress.Height / 2);
                g.DrawImage(normalHelpDesk, -normalHelpDesk.Width / 2 + 400, -normalHelpDesk.Height / 2);
            }
            else
                g.DrawImage(normal, -normal.Width / 2, -normal.Height / 2);

            if (HardButtonPress)
            {
                g.DrawImage(hardPress, -hardPress.Width / 2, -hardPress.Height / 2 + 100);
                g.DrawImage(hardHelpDesk, -hardHelpDesk.Width / 2 + 400, -hardHelpDesk.Height / 2);
            }
            else
                g.DrawImage(hard, -hard.Width / 2, -hard.Height / 2 + 100);

            if (BackButtonPress)
                g.DrawImage(backPress, -backPress.Width / 2, -backPress.Height / 2 + 300);
            else
                g.DrawImage(back, -back.Width / 2, -back.Height / 2 + 300);
        }


        private void CheckMousePressing()
        {
            if (CursorOnTheButton(easy, -100))
            {
                OffAllButtonsPress();
                EasyButtonPress = true;
                return;
            }
            else
                OffAllButtonsPress();

            if (CursorOnTheButton(normal, 0))
            {
                OffAllButtonsPress();
                NormalButtonPress = true;
                return;
            }
            else
                OffAllButtonsPress();
            if (CursorOnTheButton(hard, 100))
            {
                OffAllButtonsPress();
                HardButtonPress = true;
                return;
            }
            else
                OffAllButtonsPress();

            if (CursorOnTheButton(back, 300))
            {
                OffAllButtonsPress();
                BackButtonPress = true;
                return;
            }
            else
                OffAllButtonsPress();
        }

        private bool CursorOnTheButton(Image buttonIamage, int offset)
        {
            var coursorX = Cursor.Position.X;
            var coursorY = Cursor.Position.Y;

            return Math.Abs(ClientSize.Width / 2 - coursorX) < buttonIamage.Width / 2 &&
              (Math.Abs(ClientSize.Height / 2 + offset - coursorY) < buttonIamage.Height / 2);
        }

        private void OffAllButtonsPress()
        {
            EasyButtonPress = false;
            NormalButtonPress = false;
            HardButtonPress = false;
            BackButtonPress = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (EasyButtonPress)
            {
                var level1 = new Level(4, 2, 7, 500, Form.Size);
                Form.ShowBattleControl(level1);
                return;
            }
            if (NormalButtonPress)
            {
                var level2 = new Level(7, 3, 10, 700, Form.Size);
                Form.ShowBattleControl(level2);
                return;

            }
            if (HardButtonPress)
            {
                var level3 = new Level(13, 4, 5, 1000, Form.Size);
                Form.ShowBattleControl(level3);
                return;
            }
            if (BackButtonPress)
            {
                Form.ShowMainMenuControl();
                return;
            }
        }
    }
}

