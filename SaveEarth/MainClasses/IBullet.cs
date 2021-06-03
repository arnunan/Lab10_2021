using System.Drawing;

namespace SaveEarth.MainClasses
{
    public interface IBullet
    {
        double LocationX { get; }
        double LocationY { get; }
        double Direction { get; }
        int Damage { get; }
        BulletType TypeBullet { get; }
        bool isHit { get; }
        void Move();
        void Hit();
        Bitmap GetFrameForAnimation();
    }
}
