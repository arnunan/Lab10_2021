
using System.Drawing;

namespace SaveEarth.MainClasses
{
    public interface IAlien
    {
        double LocationX { get; }
        double LocationY { get; }
        double Direction { get; }
        double Radius { get; }
        int KillPoints { get; }
        bool isDead { get; }
        int HitBox { get; }
        bool isDropBoost { get; }
        bool CanDeleteAlien { get; }
        AttackType attackType { get; }
        bool CanDoAttack();
        void ChangeBoostStatus();
        void Move(double dt);
        Bitmap GetFrameForAnimation();
        void AnimateAlien();
        void TakeDamage(int damage);

    }

}
