using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Final_game
{
    public partial class Form1 : Form
    {
        #region Fields
        private Image Hero = Images.hero,
                      Enemy = Images.скелет;

        private Image Block = Images.block,
                      Door = Images.door,
                      Wall = Images.wall;


        private Map map;

        private Entity player, enemy1, enemy2, enemy3, enemy4, enemy5;

        private List<Environment> Boundaries_1, Boundaries_2, Boundaries_3, Boundaries_4,

                                  Doors;

        private List<Entity> Enemies_1, Enemies_2, Enemies_3, Enemies_4;

        private int currentRoom;

        private bool openDoor;
        #endregion

        public Form1()
        {
            double width = SystemParameters.PrimaryScreenWidth;
            double height = SystemParameters.PrimaryScreenHeight;

            currentRoom = 1;

            InitializeComponent();
            Init();

            BackgroundImage = Images.background;

            KeyUp += new KeyEventHandler(OnKeyUp);
            KeyDown += new KeyEventHandler(OnKeyDown);

        }

        public void Init()
        {
            player = new Entity(20, 16, 50, 37, 100, Hero, 4, 6, 6, 7);

            map = new Map();            
            Doors = map.Doors;
            CreateBoundaries(map);
            CreateEnemies();

            timer.Start();
        }

        public void CreateBoundaries(Map map)
        {
            Boundaries_1 =  map.Boundaries_1;
            Boundaries_2 = map.Boundaries_2;
            Boundaries_3 = map.Boundaries_3;
            Boundaries_4 = map.Boundaries_4;
        }
        public void CreateEnemies()
        {
            Enemies_1 = new List<Entity>();
            Enemies_2 = new List<Entity>();
            Enemies_3 = new List<Entity>();
            Enemies_4 = new List<Entity>();

            enemy1 = new Entity(90, 65, 50, 37, 15, Enemy);
            enemy2 = new Entity(50, 125, 50, 37, 15, Enemy);
            Enemies_1.Add(enemy1);
            Enemies_1.Add(enemy2);

            enemy1 = new Entity(100, 210, 50, 37, 30, Enemy);
            enemy2 = new Entity(70, 180, 50, 37, 30, Enemy);
            Enemies_2.Add(enemy1);
            Enemies_2.Add(enemy2);

            enemy1 = new Entity(410, 270, 50, 37, 60, Enemy);
            enemy2 = new Entity(480, 250, 50, 37, 60, Enemy);
            enemy3 = new Entity(260, 290, 50, 37, 60, Enemy);
            Enemies_3.Add(enemy1);
            Enemies_3.Add(enemy2);
            Enemies_3.Add(enemy3);

            enemy1 = new Entity(690, 190, 50, 37, 120, Enemy);
            enemy2 = new Entity(900, 150, 50, 37, 120, Enemy);
            enemy3 = new Entity(870, 17, 50, 37, 120, Enemy);
            enemy4 = new Entity(785, 70, 50, 37, 120, Enemy);
            enemy5 = new Entity(690, 140, 50, 37, 120, Enemy);
            Enemies_4.Add(enemy1);
            Enemies_4.Add(enemy2);
            Enemies_4.Add(enemy3);
            Enemies_4.Add(enemy4);
            Enemies_4.Add(enemy5);

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            UpdateStyles();

            if (currentRoom == 1)
            {
                openDoor = Enemies_1.Count == 0;
                player.Phisics(Boundaries_1);
                for (int i = 0; i < Enemies_1.Count; i++)
                {
                    var enemy = Enemies_1[i];
                    enemy.Moving(Boundaries_1);
                    enemy.Phisics(Boundaries_1);
                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) Enemies_1.RemoveAt(i);
                }
            }

            if (currentRoom == 2)
            {
                openDoor = Enemies_2.Count == 0;
                player.Phisics(Boundaries_2);
                for (int i = 0; i < Enemies_2.Count; i++)
                {
                    var enemy = Enemies_2[i];
                    enemy.Moving(Boundaries_2);
                    enemy.Phisics(Boundaries_2);
                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) Enemies_2.RemoveAt(i);
                }
            }

            if (currentRoom == 3)
            {
                openDoor = Enemies_3.Count == 0;
                player.Phisics(Boundaries_3);
                for (int i = 0; i < Enemies_3.Count; i++)
                {
                    var enemy = Enemies_3[i];
                    enemy.Moving(Boundaries_3);
                    enemy.Phisics(Boundaries_3);
                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) Enemies_3.RemoveAt(i);
                }
            }

            if (currentRoom == 4)
            {
                openDoor = Enemies_4.Count == 0;
                player.Phisics(Boundaries_4);
                for (int i = 0; i < Enemies_4.Count; i++)
                {
                    var enemy = Enemies_4[i];
                    enemy.Moving(Boundaries_4);
                    enemy.Phisics(Boundaries_4);
                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) Enemies_4.RemoveAt(i);
                }
            }

            Invalidate();
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                player.dx = -3;
                player.goLeft = true;
                player.flip = false;
                player.SetAniConf(1);
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                player.dx = 3;
                player.goRight = true;
                player.flip = true;
                player.SetAniConf(1);
            }   

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                if (player.isOnEarth)
                {
                    player.goUp = true;
                    player.speedY = -15;
                    player.SetAniConf(3);
                }
            }

            if (e.KeyCode == Keys.F12)
            {
                if (player.isOnEarth)
                {
                    player.goUp = true;
                    player.speedY = -30;
                    player.SetAniConf(3);
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                player.Attack = true;
                player.SetAniConf(2);
            }

            if (e.KeyCode == Keys.N)
            {
                if (player.NearDoor(Doors) && openDoor)
                {
                    switch (currentRoom)
                    {
                        case 1:
                            player.GoTo(Doors[2]);
                            currentRoom = 2;
                            break;
                        case 2:
                            player.GoTo(Doors[4]);
                            
                            currentRoom = 3;
                            break;
                        case 3:
                            player.GoTo(Doors[6]);
                            currentRoom = 4;
                            break;
                        case 4:
                            Finish();
                            break;

                    }
                }
            }
               
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.Stop();
            player.SetAniConf(0);
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (currentRoom == 1)
                foreach (var r in Enemies_1)
                    r.PlayAnimation(g);
            if (currentRoom == 2)
                foreach (var r in Enemies_2)
                    r.PlayAnimation(g);
            if (currentRoom == 3)
                foreach (var r in Enemies_3)
                    r.PlayAnimation(g);
            if (currentRoom == 4)
                foreach (var r in Enemies_4)
                    r.PlayAnimation(g);

            player.PlayAnimation(g);

        }

        public void Finish()
        {
            Form gameOver = new Form();
            gameOver.ShowDialog();

            timer.Stop();
            Close();
        }
    }
}
