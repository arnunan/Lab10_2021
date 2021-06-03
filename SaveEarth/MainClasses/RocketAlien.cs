using System;
using System.Drawing;
using System.Media;

namespace SaveEarth.MainClasses
{
    class RocketAlien : IAlien
    {
        public RocketAlien(double radius, double direction, double turnVeloncity, int healthPoint = 30, string imageName = "RocketAlien")
        {

            HealthPoint = healthPoint;
            Radius = radius;
            Direction = direction;
            LocationX = -Radius * Math.Sin(Direction);
            LocationY = Radius * Math.Cos(Direction);
            TurnVeloncity = turnVeloncity;
            HitBox = 30;
            KillPoints = 20;
            AttackRange = 500;
            isDropBoost = false;
            Velocity = 25;
            attackType = AttackType.Rocket;
        }

        static SoundPlayer sound = new SoundPlayer("../../Sounds/Bang.wav");

        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public double Direction { get; private set; }
        public double Radius { get; private set; }
        public int KillPoints { get; private set; }
        public bool isDead { get { return (HealthPoint <= 0); }}
        public int HitBox { get; private set; }
        public bool CanDeleteAlien { get; private set; }
        public bool isDropBoost { get; private set; }
        public AttackType attackType { get; private set; }

        private double AttackRange;
        private int currenAlienFrameDead = 1;
        private int currenAlienFrame = 1;
        private int HealthPoint;      
        private double Velocity;
        private double TurnVeloncity;     
        private int attackCounter;

        static private Bitmap[] RocketAlienFrames = new Bitmap[6];
        static private Bitmap[] BangFrames = new Bitmap[6];

        static public void InitializeImagesForAnimation()
        {
            for (int i = 0; i < BangFrames.Length; i++)
            {
                BangFrames[i] = new Bitmap("../../image/Sprites/Bang/bang_" + (i + 1).ToString() + ".png");
            }

            for (int i = 0; i < RocketAlienFrames.Length; i++)
            {
                RocketAlienFrames[i] = new Bitmap("../../image/Sprites/Aliens/RocketAlien/RocketAlien_" + (i + 1).ToString() + ".png");
            }
        }

        public void AnimateAlien()
        {
            if (!(HealthPoint <= 0))
            {
                if (currenAlienFrame > 5)
                    currenAlienFrame = 1;
                currenAlienFrame++;
            }
            else
            {
                PlaySound(currenAlienFrameDead);
                if (currenAlienFrameDead > 5)
                {
                    currenAlienFrameDead = 1;
                    CanDeleteAlien = true;
                }
                currenAlienFrameDead++;
            }
        }

        private void PlaySound(int frame)
        {
            if (frame == 1)
                sound.Play();
            sound.LoadAsync();
        }

        public bool CanDoAttack()
        {
            if (Radius <= AttackRange && !isDead)
            {
                if (attackCounter == 0)
                {
                    attackCounter = 200;
                    return true;
                }
                else
                {
                    attackCounter--;
                    return false;
                }
            }
            else return false;
        }

        public Bitmap GetFrameForAnimation()
        {
            if (!(HealthPoint <= 0))
                return RocketAlienFrames[currenAlienFrame - 1];
            else return BangFrames[currenAlienFrameDead - 1];
        }


        public void Move(double dt)
        {
            if (!(HealthPoint <= 0))
            {
                if (Radius >= 350)
                {
                    Radius -= Velocity * dt;
                    LocationX = -Radius * Math.Sin(Direction);
                    LocationY = Radius * Math.Cos(Direction);
                    Direction += 0.002;
                }
                else
                {
                    Direction += TurnVeloncity * 0.0005;
                    LocationX = -Radius * Math.Sin(Direction);
                    LocationY = Radius * Math.Cos(Direction);
                }

            }
        }

        public void TakeDamage(int damage)
        {
            HealthPoint -= damage;
        }

        public void ChangeBoostStatus()
        {
            isDropBoost = true;
        }
    }
}

