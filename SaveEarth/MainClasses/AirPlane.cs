using System;
using System.Drawing;


namespace SaveEarth.MainClasses
{
    public class AirPlane
    {
        public AirPlane(double radius, double direction, int numberOfAvailableRocket)
        {
            Radius = radius;
            LocationX = -Radius * Math.Sin(direction);
            LocationY = Radius * Math.Cos(direction);
            Direction = direction;
            typeBullet = BulletType.AirPlaneBullet;
            NumberOfAvailableRocket = numberOfAvailableRocket;
            MaxNumberOfAvailableRocket = numberOfAvailableRocket;
        }

        private double TurnVelocity = 0.15;
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public double Direction { get; private set; } // угол направления в радианах
        public BulletType typeBullet { get; private set; }
        public int NumberOfAvailableRocket { get; private set; }
        public int MaxNumberOfAvailableRocket { get; private set; }
        public double Radius { get; private set; }


        static private Bitmap AirPlaneLeftTurnFrames = new Bitmap("../../image/Sprites/AirPlane/LeftTurn/AirPlaneTurnLeft_1.png");
        static private Bitmap AirPlaneRightTurnFrames = new Bitmap("../../image/Sprites/AirPlane/RightTurn/AirPlaneTurnRight_1.png");
        static private Bitmap AirPlaneNoTurnFrames = new Bitmap("../../image/Sprites/AirPlane/NoTurn/AirPlane_1.png");



        private int currentAirPlaneFrame = 1;
        public void Move(Turn turn, double dt)
        {
            Direction += (turn == Turn.Left ? -TurnVelocity : turn == Turn.Right ? TurnVelocity : 0) * dt;
            LocationX = -Radius * Math.Sin(Direction);
            LocationY = Radius * Math.Cos(Direction);
        }


        public void AddRocketToTotalNumber()
        {
            if (NumberOfAvailableRocket < MaxNumberOfAvailableRocket)
                NumberOfAvailableRocket = MaxNumberOfAvailableRocket;
        }

        public void DeleteRocketFromTotalNumber()
        {
            NumberOfAvailableRocket--;
        }

        public Bitmap GetFrameForAnimation(bool isAirPlaneTurnLeft, bool isAirPlaneTurnRight)
        {
            if (isAirPlaneTurnLeft)
                return AirPlaneLeftTurnFrames;
            else if (isAirPlaneTurnRight)
                return AirPlaneRightTurnFrames;
            else return AirPlaneNoTurnFrames;
            
        }


        public void AnimateAirPlane()
        {
            if (currentAirPlaneFrame > 3)
                currentAirPlaneFrame = 1;
            currentAirPlaneFrame++;
        }
    }
}
