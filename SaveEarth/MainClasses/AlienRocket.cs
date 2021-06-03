using System;
using System.Drawing;

namespace SaveEarth.MainClasses
{
    class AlienRocket : IBullet
    {       
        public AlienRocket(double locationX, double locationY, double directoin)
        {
            LocationX = locationX;
            LocationY = locationY;
            Direction = directoin;
            Radius = Math.Sqrt(locationX * locationX + locationY * locationY);
            TypeBullet = BulletType.AlienBullet;
            Damage = 40;
        }


        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public double Direction { get; private set; }
        public int Damage { get; private set; }
        public BulletType TypeBullet { get; private set; }
        public bool isHit { get; private set; }
        

        private double Radius;
        private int currentRocketFrame = 1;
        private double Velocity = 0;

        static private Bitmap[] AlienRocketFrames = new Bitmap[4];

        static public void InitializeImagesForAnimation()
        {
            for (int i = 0; i < AlienRocketFrames.Length; i++)
            {
                AlienRocketFrames[i] = new Bitmap("../../image/Sprites/Rockets/AlienRocket/Rocket_" + (i + 1).ToString() + ".png");
            }
        }

        public Bitmap GetFrameForAnimation()
        {
            AnimateRocket();
            return AlienRocketFrames[currentRocketFrame - 1];
        }

        public void AnimateRocket()
        {
            if (currentRocketFrame >= 3)
                currentRocketFrame = 1;
            currentRocketFrame++;
        }

        public void Hit()
        {
            isHit = true;
        }

        public void Move()
        {
            Radius -= Velocity;
            LocationX = -Radius * Math.Sin(Direction);
            LocationY = Radius * Math.Cos(Direction);
            Velocity += 0.5;
        }
    }
}
