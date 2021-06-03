using System.Drawing;


namespace SaveEarth.MainClasses
{
    public interface IBoost
    {
        double Direction { get; }
        double LocationX { get; }
        double LocationY { get; }
        bool isTaken { get; }
        void Move();
        void Take();
        Bitmap GetFrameForAnimation();
        BoostType GiveBoost();
    }
}
