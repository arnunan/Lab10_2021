using System;
using System.Drawing;

namespace SaveEarth.MainClasses
{
    public class HealthPointsBoost : IBoost
    {
        public double Direction { get; private set; }
        private double Velocity;
        private double TurnVelocity;
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public bool isTaken { get; private set; }
        private double Radius;
        private BoostType Boost;

        static Bitmap HealthPointsBoostFrame = new Bitmap("../../image/Sprites/Boosts/HealthPointsBoost/HealthPointsBoost_1.png");

        public HealthPointsBoost(double radius, double direction, double turnVelocity)
        {
            Radius = radius;
            Direction = direction;
            LocationX = -Radius * Math.Sin(Direction);
            LocationY = Radius * Math.Cos(Direction);
            TurnVelocity = turnVelocity;
            Boost = BoostType.HealthPointsBoost;
            Velocity = 5;
        }

        public void Move()
        {
            if (!isTaken)
            {
                if (Radius >= 50)
                {
                    Radius -= Velocity * 0.3;
                    LocationX = -Radius * Math.Sin(Direction);
                    LocationY = Radius * Math.Cos(Direction);
                    Direction += TurnVelocity * 0.005;
                }
                else isTaken = true;
            }
        }

        public void Take()
        {
            isTaken = true;
        }

        public Bitmap GetFrameForAnimation()
        {
            return HealthPointsBoostFrame;
        }

        public BoostType GiveBoost() => Boost;
    }
}
