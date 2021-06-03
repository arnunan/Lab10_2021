using System;
using System.Drawing;


namespace SaveEarth.MainClasses
{
    public class AirPlaneBullet : IBullet
    {
        public double Direction { get; private set; }
        public int Damage { get; private set; }

        private double Velocity;
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public BulletType TypeBullet { get; private set; }
        public bool isHit { get; private set; }
        private double Radius;
        static private Bitmap AirPlaneBulletImg = new Bitmap("../../image/Sprites/Bullets/AirPlaneBullet.png");
      
        public AirPlaneBullet( double locationY, double directoin)
        {
            Radius = locationY;
            Direction = directoin;
            LocationY = Radius * Math.Cos(Direction);
            LocationX = -Radius * Math.Sin(Direction);       
            TypeBullet = BulletType.AirPlaneBullet;
            Damage = 10;
            Velocity = 20;
        }

        public void Move()
        {
            Radius += Velocity;
            LocationX = -Radius * Math.Sin(Direction);
            LocationY = Radius * Math.Cos(Direction);
        }

        public void Hit()
        {
            isHit = true;
        }

        public Bitmap GetFrameForAnimation()
        {
            return AirPlaneBulletImg;
        }
    }
}

