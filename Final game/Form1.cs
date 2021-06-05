using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Final_game
{
    public partial class Form1 : Form
    {
        #region Fields
        private readonly Image Hero = Images.hero,
                               Enemy = Images.скелет,
                               Lifebar = Images.lifebar;

          
        private readonly Image Wall = Images.wall,
                               Heart = Images.Heart;

        private Map map;

        private Entity player, enemy1, enemy2, enemy3, enemy4, enemy5, 
                       heart, heart2;

        private Lifebar lifebar;

        private List<Environment> Boundaries_1, Boundaries_2, Boundaries_3, Boundaries_4,
                                  Doors;

        private List<Entity> Enemies_1, Enemies_2, Enemies_3, Enemies_4;

        private int currentRoom;

        private bool openDoor;

        private bool gamePaused;

        private bool flag;
        #endregion

        public Form1()
        {
            currentRoom = 1;

            InitializeComponent();

            BackgroundImage = Images.background;

            KeyUp += new KeyEventHandler(OnKeyUp);
            KeyDown += new KeyEventHandler(OnKeyDown);

            Init();
        }

        public void Init()
        {
            player = new Entity(20, 16, 50, 37, 500, Hero, 4, 6, 6, 7);
            heart = new Entity(635, 280, 18, 14, 100, Heart, 8);
            heart2 = new Entity(880, 40, 18, 14, 200, Heart, 8);

            map = new Map();            
            Doors = map.Doors;
            CreateBoundaries(map);
            CreateEnemies();

            timer.Start();
            gamePaused = false;
        }

        public void CreateBoundaries(Map map)
        {
            Boundaries_1 = map.Boundaries_1;
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

            enemy1 = new Entity(130, 65, 50, 37, 20, Enemy);
            enemy2 = new Entity(50, 125, 50, 37, 20, Enemy);
            Enemies_1.Add(enemy1);
            Enemies_1.Add(enemy2);

            enemy1 = new Entity(110, 230, 50, 37, 40, Enemy);
            enemy2 = new Entity(70, 180, 50, 37, 40, Enemy);
            Enemies_2.Add(enemy1);
            Enemies_2.Add(enemy2);

            enemy1 = new Entity(410, 270, 50, 37, 80, Enemy);
            enemy2 = new Entity(480, 250, 50, 37, 80, Enemy);
            enemy3 = new Entity(530, 290, 50, 37, 80, Enemy);
            Enemies_3.Add(enemy1);
            Enemies_3.Add(enemy2);
            Enemies_3.Add(enemy3);

            enemy1 = new Entity(690, 190, 50, 37, 150, Enemy);
            enemy2 = new Entity(900, 150, 50, 37, 150, Enemy);
            enemy3 = new Entity(870, 17, 50, 37, 150, Enemy);
            enemy4 = new Entity(785, 70, 50, 37, 150, Enemy);
            enemy5 = new Entity(690, 140, 50, 37, 150, Enemy);
            Enemies_4.Add(enemy1);
            Enemies_4.Add(enemy2);
            Enemies_4.Add(enemy3);
            Enemies_4.Add(enemy4);
            Enemies_4.Add(enemy5);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            UpdateStyles();

            if (player.health < 0)
                Restart();

            if (currentRoom == 1)
            {
                Doors[0].SetAniConf(1);

                openDoor = Enemies_1.Count == 0;                
                player.Phisics(Boundaries_1);

                for (int i = 0; i < Enemies_1.Count; i++)
                {
                    var enemy = Enemies_1[i];
                    enemy.Moving();
                    enemy.Phisics(Boundaries_1);

                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) 
                        Enemies_1.RemoveAt(i);

                    if (enemy.BotAttack() && player.ContactEnemy(enemy))
                    {
                        bool side = player.posX + player.sizeX / 2 > enemy.posX + enemy.sizeX / 2;
                        player.GetDamage(side, Boundaries_1, 5);                     
                    }
                }

                if (openDoor && player.NearDoor(Doors))
                {
                    Doors[1].SetAniConf(1);
                }
            }

            if (currentRoom == 2)
            {
                Doors[2].SetAniConf(1);

                openDoor = Enemies_2.Count == 0;
                player.Phisics(Boundaries_2);

                for (int i = 0; i < Enemies_2.Count; i++)
                {
                    var enemy = Enemies_2[i];
                    enemy.Moving();
                    enemy.Phisics(Boundaries_2);

                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) Enemies_2.RemoveAt(i);

                    if (enemy.BotAttack() && player.ContactEnemy(enemy))
                    {
                        bool side = player.posX + player.sizeX / 2 > enemy.posX + enemy.sizeX / 2;
                        player.GetDamage(side, Boundaries_2, 8);
                    }
                }

                if (openDoor && player.NearDoor(Doors))
                {
                    Doors[3].SetAniConf(1);
                }
            }

            if (currentRoom == 3)
            {
                Doors[4].SetAniConf(1);
                heart.SetAniConf(0);

                openDoor = Enemies_3.Count == 0;
                player.Phisics(Boundaries_3);

                for (int i = 0; i < Enemies_3.Count; i++)
                {
                    var enemy = Enemies_3[i];
                    enemy.Moving();
                    enemy.Phisics(Boundaries_3);

                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) Enemies_3.RemoveAt(i);

                    if (enemy.BotAttack() && player.ContactEnemy(enemy))
                    {
                        bool side = player.posX + player.sizeX / 2 > enemy.posX + enemy.sizeX / 2;
                        player.GetDamage(side, Boundaries_3, 13);
                    }
                }

                if (openDoor && !flag)
                {
                    Boundaries_3.Add(new Environment(235, 280, 2, 55, Wall));
                    Boundaries_3.Add(new Environment(704, 327, 50, 1, Wall));
                    flag = true;
                }

                if (openDoor && player.NearDoor(Doors))
                {
                    Doors[5].SetAniConf(1);
                }

                if (player.Attack && player.ContactEnemy(heart))
                    heart.health -= 5;

                if (heart.health < 1)
                {
                    player.health += 300;
                    heart.spriteSheet = Wall;
                    heart.health = 10;
                }
            }

            if (currentRoom == 4)
            {
                Doors[6].SetAniConf(1);
                heart2.SetAniConf(0);

                openDoor = Enemies_4.Count == 0;
                player.Phisics(Boundaries_4);

                for (int i = 0; i < Enemies_4.Count; i++)
                {
                    var enemy = Enemies_4[i];
                    enemy.Moving();
                    enemy.Phisics(Boundaries_4);

                    if (player.Attack && player.ContactEnemy(enemy))
                        enemy.health -= 1;
                    if (enemy.health < 1) Enemies_4.RemoveAt(i);

                    if (enemy.BotAttack() && player.ContactEnemy(enemy))
                    {
                        bool side = player.posX + player.sizeX / 2 > enemy.posX + enemy.sizeX / 2;
                        player.GetDamage(side, Boundaries_4, 17);
                    }
                }

                if (openDoor && player.NearDoor(Doors))
                {
                    Doors[7].SetAniConf(1);
                }

                if (player.Attack && player.ContactEnemy(heart2))
                    heart2.health -= 1;

                if (heart2.health < 1)
                {
                    player.health += 300;
                    heart2.spriteSheet = Wall;
                    heart2.health = 30;
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
                    player.speedY = -17;
                    player.SetAniConf(3);
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                player.Attack = true;
                player.SetAniConf(2);
            }

            if (e.KeyCode == Keys.R)
                Restart();

            if (e.KeyCode == Keys.P)
            {
                if (!gamePaused)
                {
                    timer.Stop();
                    gamePaused = true;
                }
                else
                {
                    timer.Start();
                    gamePaused = false;
                }
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
                            Restart();
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

            foreach (var door in Doors)
                door.PlayAnimation(g);

            if (currentRoom == 1)
                foreach (var r in Enemies_1)
                    r.PlayAnimation(g);
            if (currentRoom == 2)
                foreach (var r in Enemies_2)
                    r.PlayAnimation(g);
            if (currentRoom == 3)
            {
                foreach (var r in Enemies_3)
                    r.PlayAnimation(g);
                heart.PlayAnimation(g);
            }
            if (currentRoom == 4)
            {
                heart2.PlayAnimation(g);
                foreach (var r in Enemies_4)
                    r.PlayAnimation(g);
            }

            lifebar = new Lifebar(player);
            lifebar.Draw(g);
            player.PlayAnimation(g);

        }
        
        public void Restart()
        {
            currentRoom = 1;
            Init();
        }
    }
}
