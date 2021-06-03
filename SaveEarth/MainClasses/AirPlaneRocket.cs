using System;
using System.Drawing;


namespace SaveEarth.MainClasses
{
    public class AirPlaneRocket : IBullet
    {

        public AirPlaneRocket(double radius, double directoin)
        {
            LocationX = -radius * Math.Sin(directoin);
            LocationY = radius * Math.Cos(directoin);
            Direction = directoin;
            Radius = radius;
            TypeBullet = BulletType.AirPlaneBullet;
            Damage = 50;

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

        static private Bitmap[] RocketFrames = new Bitmap[4];

        static public void InitializeImagesForAnimation()
        {
            for (int i = 0; i < RocketFrames.Length; i++)
            {
                RocketFrames[i] = new Bitmap("../../image/Sprites/Rockets/Rocket_" + (i + 1).ToString() + ".png");
            }
        }

        public Bitmap GetFrameForAnimation()
        {
            AnimateRocket();
           return RocketFrames[currentRocketFrame - 1];
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
            Radius += Velocity;
            LocationX = -Radius * Math.Sin(Direction);
            LocationY = Radius * Math.Cos(Direction);
            Velocity += 0.5;
        }
    }
}
