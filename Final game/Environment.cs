using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_game
{
    public class Environment
    {
        #region Fields
        public int posX, posY;

        public int sizeX, sizeY;

        public int centreX, centreY;

        public int currentFrames, currentAnimation, frameLimit;

        public Image spriteSheet;
        #endregion

        public Environment(int posX, int posY, int sizeX, int sizeY, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.spriteSheet = spriteSheet;

            centreX = posX + sizeX / 2;
            centreY = posY + sizeY / 2;

        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrames == frameLimit)
                currentFrames--;
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(sizeX, sizeY)),
                sizeX*currentFrames, sizeY*currentAnimation, sizeX, sizeY, GraphicsUnit.Pixel);
            currentFrames++;
        }

        public void SetAniConf(int curAni)
        {
            if (curAni == 0)
                frameLimit = 1;
            if (curAni == 1)
                frameLimit = 5;
            if (curAni == 2)
                frameLimit = 3;

            currentAnimation = curAni;
        }
    }
}
