using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaveEarth.Views
{
    public partial class MainMenuControl : UserControl
    {

        private MainForm Form;
        private int CurrentAnomationSprite = 1;
        private Timer MainTimer = new Timer { Interval = 100 };
        private Timer timerForAnimation = new Timer { Interval = 350 };


        private Bitmap background = new Bitmap("../../image/Menu/Background/backgroundSpace.png");
        private Bitmap start = new Bitmap("../../image/Menu/Buttons/Start.png");
        private Bitmap exit = new Bitmap("../../image/Menu/Buttons/Exit.png");
        private Bitmap startPress = new Bitmap("../../image/Menu/Buttons/StartPress.png");
        private Bitmap exitPress = new Bitmap("../../image/Menu/Buttons/ExitPress.png");

        private Bitmap[] logeframes = new Bitmap[]
         {
            new Bitmap("../../image/Menu/Logo/LOGO3_1.png"),
            new Bitmap("../../image/Menu/Logo/LOGO3_2.png"),
            new Bitmap("../../image/Menu/Logo/LOGO3_3.png"),
            new Bitmap("../../image/Menu/Logo/LOGO3_4.png"),
            new Bitmap("../../image/Menu/Logo/LOGO3_5.png"),
            new Bitmap("../../image/Menu/Logo/LOGO3_6.png")
        };




        private bool StartButtonPress = false;
        private bool ExitButtonPress = false;



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public MainMenuControl(MainForm form)
        {
            InitializeComponent();
            Form = form;

            this.BackColor = Color.Black;
            // ClientSize = new Size(Form.Width, Form.Height);
            ClientSize = Form.Size;
            this.AutoScaleMode = AutoScaleMode.Dpi;

            timerForAnimation = new Timer { Interval = 500 };
            timerForAnimation.Tick += TimerForAnimationTick;
            timerForAnimation.Start();

            MainTimer.Tick += MainTimerTick;
            MainTimer.Start();
        }


        private void TimerForAnimationTick(object sender, EventArgs e)
        {
            AnimateLogo();
        }

        private void AnimateLogo()
        {
            if (CurrentAnomationSprite > 5)
                CurrentAnomationSprite = 1;
            CurrentAnomationSprite++;
        }

        private void MainTimerTick(object sender, EventArgs e)
        {
            Invalidate();
            Update();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (StartButtonPress)
            {
                Form.ShowLevelSelectionComntrol();
                return;
            }
            if (ExitButtonPress)
            {
                Application.Exit();
            }
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

            var logo = logeframes[CurrentAnomationSprite - 1];
            g.DrawImage(logo, -logo.Width / 2, -logo.Height / 2 - 200);

            if (StartButtonPress)
                g.DrawImage(startPress, -start.Width / 2, -start.Height / 2 + 20);
            else
                g.DrawImage(start, -start.Width / 2, -start.Height / 2 + 20);
            if (ExitButtonPress)
                g.DrawImage(exitPress, -exit.Width / 2, -exit.Height / 2 + 120);
            else
                g.DrawImage(exit, -exit.Width / 2, -exit.Height / 2 + 120);
        }

        private void CheckMousePressing()
        {
            if (CursorOnTheButton(start, 20))
            {
                StartButtonPress = true;
                ExitButtonPress = false;
                return;
            }
            else
            {
                StartButtonPress = false;
                ExitButtonPress = false;
            }

            if (CursorOnTheButton(exit, 120))
            {
                ExitButtonPress = true;
                StartButtonPress = false;
                return;
            }
            else
            {
                StartButtonPress = false;
                ExitButtonPress = false;
            }
        }
        private bool CursorOnTheButton(Bitmap buttonIamage, int offset)
        {
            var coursorX = Cursor.Position.X;
            var coursorY = Cursor.Position.Y;

            return Math.Abs(ClientSize.Width / 2 - coursorX) < buttonIamage.Width / 2 &&
              (Math.Abs(ClientSize.Height / 2 + offset - coursorY) < buttonIamage.Height / 2);
        }
    }
}

