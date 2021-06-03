using System.Drawing;


namespace SaveEarth.MainClasses
{
    public class Earth
    {
        public Earth(double locationX, double locationy, int healthPoint)
        {
            LocationX = locationX;
            LocationY = locationy;
            HealthPoint = healthPoint;
            MaxHealthPoint = healthPoint;
            HitBox = 100;
        }

        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public int HealthPoint { get; private set; }
        public int MaxHealthPoint { get; private set; }
        public int HitBox { get; private set; }
        private int currentEarthFrame = 1;
        private int currenAlienFrameDead = 1;
        public bool isDead { get { return HealthPoint <= 0; } }
        public bool isCanEnd { get; private set; }


        static private Bitmap[] DeadOfEarthFrames = new Bitmap[10];
        static private Bitmap[] LifeOfEarthFrames = new Bitmap[10];

        static public void InitializeImagesForAnimation()
        {
            for (int i = 0; i < LifeOfEarthFrames.Length; i++)
            {
                LifeOfEarthFrames[i] = new Bitmap("../../image/Sprites/Earth/LifeOfEarth/Earth_" + (i + 1).ToString() + ".png");
            }

            for (int i = 0; i < DeadOfEarthFrames.Length; i++)
            {
                DeadOfEarthFrames[i] = new Bitmap("../../image/Sprites/Earth/DeadOfEarth/Earth_" + (i + 1).ToString() + ".png");
            }

        }

        public void TakeDamage(int damege)
        {
            HealthPoint -= damege;
            if (HealthPoint < 0) HealthPoint = 0;
            if (HealthPoint > MaxHealthPoint) HealthPoint = MaxHealthPoint;
        }

        public Bitmap GetFrameForAnimation()
        {
            if (!isDead)
                return LifeOfEarthFrames[currentEarthFrame - 1];
            else return DeadOfEarthFrames[currenAlienFrameDead - 1];
        }

        public void AnimateEarth()
        {
            if (!isDead)
            {
                if (currentEarthFrame > 9)
                    currentEarthFrame = 1;
                currentEarthFrame++;
            }
            else
            {
                if (currenAlienFrameDead > 9)
                {
                    isCanEnd = true;
                    currenAlienFrameDead = 9;
                }
                currenAlienFrameDead++;
            }
        }

    }
}
