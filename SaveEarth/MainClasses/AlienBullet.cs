using System;
using System.Drawing;


namespace SaveEarth.MainClasses
{
    class AlienBullet : IBullet
    {
        public double Direction { get; private set; }
        public int Damage { get; private set; }

        private double Velocity;
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public BulletType TypeBullet { get; private set; }
        public bool isHit { get; private set; }
        private double Radius;

        static private Bitmap AlienBulletImg = new Bitmap("../../image/Sprites/Bullets/AlienBullet.png");

        public AlienBullet(double locationX, double locationY, double directoin, BulletType typeBullet)
        {
            LocationX = locationX;
            LocationY = locationY;
            Direction = directoin;
            Radius = Math.Sqrt(locationX * locationX + locationY * locationY);
            TypeBullet = typeBullet;
            Damage = 10;
            Velocity = -20;
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
            return AlienBulletImg;
        }
    }
}

