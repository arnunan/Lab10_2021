﻿using SaveEarth.MainClasses;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaveEarth.Views
{
    public partial class BattleControl : UserControl
    {
        private MainForm Form;

        private Level CurrentLevel;

        private Timer mainTimer;
        private Timer timerForAnimation;
        private Timer timerForShooting;

        private bool isAirPlaneTurnLeft;
        private bool isAirPlaneTurnRight;
        private bool isShooting = true;
        private bool isPaused = false;
        private bool menuButtonPress = false;
        private bool restartButtonPress = false;
        private bool pauseMenuOn = false;
        private bool resumeButtonPress = false;
        private bool menuButtonOnLoseDeskPress = false;
        private bool tutorialIsEnded = false;

        private Bitmap backgroundImg = new Bitmap("../../image/Menu/Background/backgroundSpace.png");
        private Bitmap infoBar = new Bitmap("../../image/Menu/InfoBar/infoBar.png");
        private Bitmap dimming = new Bitmap("../../image/Menu/Desks/LoseDesk/DimmingFrame.png");
        private Bitmap loseDesk = new Bitmap("../../image/Menu/Desks/LoseDesk/LoseDesk.png");
        private Bitmap menu = new Bitmap("../../image/Menu/Desks/LoseDesk/Menu.png");
        private Bitmap menuPress = new Bitmap("../../image/Menu/Desks/LoseDesk/MenuPress.png");
        private Bitmap restart = new Bitmap("../../image/Menu/Desks/LoseDesk/ResrtartLvl.png");
        private Bitmap restartPress = new Bitmap("../../image/Menu/Desks/LoseDesk/ResrtartLvlPress.png");
        private Bitmap pause = new Bitmap("../../image/Menu/Desks/PauseDesk/Pause.png");
        private Bitmap resume = new Bitmap("../../image/Menu/Desks/PauseDesk/Resume.png");
        private Bitmap resumePress = new Bitmap("../../image/Menu/Desks/PauseDesk/ResumePress.png");

        private int tutorialFrame = 1;

        static Bitmap[] tutorialFrames = new Bitmap[]
        {
            new Bitmap("../../image/Tutorial/Tutorial_1.png"),
            new Bitmap("../../image/Tutorial/Tutorial_2.png"),
            new Bitmap("../../image/Tutorial/Tutorial_3.png"),
            new Bitmap("../../image/Tutorial/Tutorial_4.png"),
            new Bitmap("../../image/Tutorial/Tutorial_5.png"),
            new Bitmap("../../image/Tutorial/Tutorial_6.png"),
            new Bitmap("../../image/Tutorial/Tutorial_7.png"),
         };

        static Bitmap[] infoBarRocketsFrames = new Bitmap[]
        {
            new Bitmap("../../image/Menu/InfoBar/infoBarRockets_0.png"),
            new Bitmap("../../image/Menu/InfoBar/infoBarRockets_1.png"),
            new Bitmap("../../image/Menu/InfoBar/infoBarRockets_2.png"),
            new Bitmap("../../image/Menu/InfoBar/infoBarRockets_3.png"),
            new Bitmap("../../image/Menu/InfoBar/infoBarRockets_4.png"),
         };

        static Bitmap enterFrame = new Bitmap("../../image/Tutorial/Tutorial_Enter.png");



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public BattleControl(Level currentLevel, MainForm form)
        {
            InitializeComponent();
            Form = form;
            // ClientSize = new Size(Form.Width, Form.Height);
            ClientSize = Form.Size;
            this.AutoScaleMode = AutoScaleMode.Dpi;

            CurrentLevel = currentLevel;
            mainTimer = new Timer { Interval = 30 };
            mainTimer.Tick += MainTimerTick;
            mainTimer.Start();

            timerForAnimation = new Timer { Interval = 500 };
            timerForAnimation.Tick += TimerForAnimationTick;
            timerForAnimation.Start();

            timerForShooting = new Timer { Interval = 300 };
            timerForShooting.Tick += TimerForShootingTick;
        }


        private void TimerForAnimationTick(object sender, EventArgs e)
        {
            if (CurrentLevel == null) return;
            CurrentLevel.CurrentPlanet.AnimateEarth();
            CurrentLevel.AirPlane.AnimateAirPlane();
            foreach (var alien in CurrentLevel.GetAliens())
            {
                alien.AnimateAlien();
            }
        }

        private void MainTimerTick(object sender, EventArgs e)  
        {
            if (CurrentLevel == null) return;
            MoveAirPlane();
            Invalidate();
            Update();
        }

        //Рисование
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, ClientRectangle);
            e.Graphics.InterpolationMode = InterpolationMode.Low;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Draw(e.Graphics);
        }

        private void Draw(Graphics g)
        {
            if (CurrentLevel == null) return;

            if (CurrentLevel.IsLose) isPaused = true;

            var earthImage = CurrentLevel.CurrentPlanet.GetFrameForAnimation();

            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);
            g.DrawImage(backgroundImg, -backgroundImg.Width / 2 - 200, -backgroundImg.Height / 2 - 100);
            var tempMatrix = g.Transform;

            //Рисуем самолет
            DrawAirPlane(g);
            if (!isPaused && !CurrentLevel.CurrentPlanet.isDead)
            {
                CurrentLevel.CheckForHits();//Проверяем попадание снарядов
                CurrentLevel.DeleteDeadAlienFromBattle();//Удалем побежденных инопланетян
                CurrentLevel.CheckForBoost();//"Подбираем бусты"
                CurrentLevel.DeleteTakenBoosts();//Удаляем подобраные бусты
                CurrentLevel.DeleteBulletFromBattle(ClientSize);//удаляем все снаряды, вылетевшие за игровое поле или попавшие в протиника
            }
            //рисуем снаряды
            DrawBullets(g, tempMatrix);
            //Рисуем инопланетян
            DrawAliens(g, tempMatrix);
            //Рисуем бусты
            DrawBoosts(g, tempMatrix);


            g.Transform = tempMatrix;
            //Рисуем Землю
            g.DrawImage(earthImage, -earthImage.Width / 2 - 30, -earthImage.Height / 2 - 25);

            DrawInfoBar(g);

            if (isPaused && CurrentLevel.IsLose)
                DrawLoseDesk(g);

            if (pauseMenuOn)
                DrawPauseMenuDesk(g);

            if (!tutorialIsEnded)
                DrawTutorial(g);
        }

        private void DrawTutorial(Graphics g)
        {
            if (tutorialFrame > 7)
            {
                tutorialIsEnded = true;
                return;
            }
            if (isPaused) return;
            var offsetY = ClientSize.Height / 2 - 100;
            g.DrawImage(tutorialFrames[tutorialFrame - 1], -tutorialFrames[tutorialFrame - 1].Width / 2, -tutorialFrames[tutorialFrame - 1].Height / 2 + offsetY);
            g.DrawImage(enterFrame, -enterFrame.Width / 2 - 600, -enterFrame.Height / 2 + offsetY);

        }

        private void DrawPauseMenuDesk(Graphics g)
        {
            CheckMousePressingPauseDesk();
            g.DrawImage(dimming, -dimming.Width / 2, -dimming.Height / 2);
            g.DrawImage(pause, -pause.Width / 2, -pause.Height / 2 - 200);

            if (menuButtonPress)
                g.DrawImage(menuPress, -menuPress.Width / 2, -menuPress.Height / 2);
            else g.DrawImage(menu, -menu.Width / 2, -menu.Height / 2);

            if (resumeButtonPress)
                g.DrawImage(resumePress, -resumePress.Width / 2, -resumePress.Height / 2 - 75);
            else
                g.DrawImage(resume, -resume.Width / 2, -resume.Height / 2 - 75);

        }

        private void DrawInfoBar(Graphics g)
        {
            var infoBarRockets = infoBarRocketsFrames[CurrentLevel.AirPlane.NumberOfAvailableRocket];
            g.DrawImage(infoBar, -ClientSize.Width / 2, -ClientSize.Height / 2);
            g.DrawImage(infoBarRockets, -ClientSize.Width / 2 + infoBar.Width + 10, -ClientSize.Height / 2);
            var dx = CurrentLevel.CurrentPlanet.HealthPoint * 100 / CurrentLevel.CurrentPlanet.MaxHealthPoint;
            g.DrawLine(new Pen(Color.Red, 20), new Point(-ClientSize.Width / 2 + 120, -ClientSize.Height / 2 + 52), new Point(dx - ClientSize.Width / 2 + 120, -ClientSize.Height / 2 + 52));
        }

        private void DrawLoseDesk(Graphics g)
        {
            CheckMousePressingLoseDesk();
            g.DrawImage(dimming, -dimming.Width / 2, -dimming.Height / 2);
            g.DrawImage(loseDesk, -loseDesk.Width / 2, -loseDesk.Height / 2);
            g.DrawString(CurrentLevel.Score.ToString(), new Font("PlayMeGames", 40, FontStyle.Bold),
                new SolidBrush(Color.White), 50, -25);

            if (menuButtonOnLoseDeskPress)
                g.DrawImage(menuPress, -menuPress.Width / 2 - 80, -menuPress.Height / 2 + 100);
            else
                g.DrawImage(menu, -menu.Width / 2 - 80, -menu.Height / 2 + 100);

            if (restartButtonPress)
                g.DrawImage(restartPress, -restartPress.Width / 2 + 100, -restartPress.Height / 2 + 100);
            else
                g.DrawImage(restart, -restart.Width / 2 + 100, -restart.Height / 2 + 100);


        }

        private void DrawAirPlane(Graphics g)
        {
            Bitmap airPlaneImage = CurrentLevel.AirPlane.GetFrameForAnimation(isAirPlaneTurnLeft, isAirPlaneTurnRight);
            g.TranslateTransform((float)CurrentLevel.AirPlane.LocationX, (float)CurrentLevel.AirPlane.LocationY);
            g.RotateTransform((float)(CurrentLevel.AirPlane.Direction * 180 / Math.PI));
            g.DrawImage(airPlaneImage, -airPlaneImage.Width / 2, -airPlaneImage.Height / 2);
        }

        private void DrawBoosts(Graphics g, Matrix tempMatrix)
        {
            foreach (var boost in CurrentLevel.GetBosts())
            {
                g.Transform = tempMatrix;
                if (!isPaused)
                    boost.Move();
                g.TranslateTransform((float)boost.LocationX, (float)boost.LocationY);
                g.DrawImage(boost.GetFrameForAnimation(), -boost.GetFrameForAnimation().Width / 2, -boost.GetFrameForAnimation().Height / 2);
            }
        }

        private void DrawBullets(Graphics g, Matrix tempMatrix)
        {
            foreach (var bullet in CurrentLevel.GetBullets())
            {
                g.Transform = tempMatrix;
                if (!isPaused)
                    bullet.Move();
                g.TranslateTransform((float)bullet.LocationX, (float)bullet.LocationY);
                g.RotateTransform((float)(bullet.Direction * 180 / Math.PI));
                g.DrawImage(bullet.GetFrameForAnimation(), -bullet.GetFrameForAnimation().Width / 2, -bullet.GetFrameForAnimation().Height / 2);
            }
        }

        private void DrawAliens(Graphics g, Matrix tempMatrix)
        {
            foreach (var alien in CurrentLevel.GetAliens())
            {
                g.Transform = tempMatrix;
                if (!isPaused)
                {
                    alien.Move(0.03);
                    if (alien.CanDoAttack())
                        CurrentLevel.AlienAttack(alien);
                }
                g.TranslateTransform((float)alien.LocationX, (float)alien.LocationY);
                g.DrawImage(alien.GetFrameForAnimation(), -alien.GetFrameForAnimation().Width / 2, -alien.GetFrameForAnimation().Height / 2);
            }
        }

        //Управление
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!isPaused && !CurrentLevel.IsLose)
            {
                HandleKey(e.KeyCode, true);
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        DoShooting();
                        break;
                    case Keys.Escape:
                        {
                            isPaused = true;
                            pauseMenuOn = true;
                        }
                        break;
                    case Keys.W:
                        FireRocket();
                        break;
                    case Keys.Enter:
                        {
                            if (!tutorialIsEnded)
                                tutorialFrame++;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            HandleKey(e.KeyCode, false);
        }

        //стрельба самолета
        private void TimerForShootingTick(object sender, EventArgs e)
        {
            if (CurrentLevel == null) return;
            isShooting = true;
            timerForShooting.Stop();
        }

        private void DoShooting()
        {
            if (isShooting)
            {
                CurrentLevel.AddAirPlaneBulletToBattle();
                timerForShooting.Start();
                isShooting = false;
            }
        }

        private void FireRocket()
        {
            CurrentLevel.AddRocketToBattleForAirPlane();
        }

        //Движение Самолета
        private void MoveAirPlane()
        {
            CurrentLevel.AirPlane.Move(isAirPlaneTurnLeft ? Turn.Left : (isAirPlaneTurnRight ? Turn.Right : Turn.None), 0.3);
        }

        private void HandleKey(Keys e, bool down)
        {
            if (e == Keys.A) isAirPlaneTurnLeft = down;
            if (e == Keys.D) isAirPlaneTurnRight = down;
        }


        private void CheckMousePressingLoseDesk()
        {
            if (CursorOnTheButton(menu, -80, 100))
            {
                OffAllButtonsPress();
                menuButtonOnLoseDeskPress = true;
                return;
            }
            else
                OffAllButtonsPress();

            if (CursorOnTheButton(restart, 100, 100))
            {
                OffAllButtonsPress();
                restartButtonPress = true;
                return;
            }
            else OffAllButtonsPress();
        }

        private void CheckMousePressingPauseDesk()
        {
            if (CursorOnTheButton(resume, 0, -75))
            {
                OffAllButtonsPress();
                resumeButtonPress = true;
                return;
            }
            else OffAllButtonsPress();

            if (CursorOnTheButton(menu, 0, 0))
            {
                OffAllButtonsPress();
                menuButtonPress = true;
                return;
            }
            else OffAllButtonsPress();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (menuButtonOnLoseDeskPress)
            {
                Form.ShowMainMenuControl();
                mainTimer.Stop();
            }
            if (restartButtonPress)
            {
                if (!tutorialIsEnded)
                    tutorialFrame = 1;
                CurrentLevel = new Level(CurrentLevel.maxAliensInBattle, CurrentLevel.AirPlane.MaxNumberOfAvailableRocket,
                    CurrentLevel.ChanceBoostDrop, CurrentLevel.CurrentPlanet.MaxHealthPoint, new Size(ClientSize.Width, ClientSize.Height));
                isPaused = false;
            }
            if (menuButtonPress)
            {

                Form.ShowMainMenuControl();
                if (!tutorialIsEnded)
                    tutorialFrame = 1;
                isPaused = false;
                pauseMenuOn = false;
                mainTimer.Stop();
            }
            if (resumeButtonPress)
            {
                isPaused = false;
                pauseMenuOn = false;
            }
        }


        private bool CursorOnTheButton(Bitmap buttonIamage, int offsetX, int offsetY)
        {
            var coursorX = Cursor.Position.X;
            var coursorY = Cursor.Position.Y;

            return Math.Abs(ClientSize.Width / 2 + offsetX - coursorX) < buttonIamage.Width / 2 &&
              (Math.Abs(ClientSize.Height / 2 + offsetY - coursorY) < buttonIamage.Height / 2);
        }

        private void OffAllButtonsPress()
        {
            menuButtonPress = false;
            restartButtonPress = false;
            resumeButtonPress = false;
            menuButtonOnLoseDeskPress = false;
        }

        public void ChangeCurrentLevel(Level newLevel)
        {
            CurrentLevel = newLevel;
            mainTimer.Start();
            isPaused = false;
        }
    }
}
