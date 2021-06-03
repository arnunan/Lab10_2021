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

        public int currentFrames, currentAnimation;

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
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(sizeX, sizeY)),
                0, 0, sizeX, sizeY, GraphicsUnit.Pixel);
        }
    }
}
