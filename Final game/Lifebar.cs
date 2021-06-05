using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_game
{
    class Lifebar
    {

        public int posX, posY;
        public int sizeX, sizeY;
        private Image image = Images.lifebar;
        public Lifebar(Entity player)
        {
            posX = player.posX + 10;
            posY = player.posY;
            sizeY = 5;
            sizeX = CalculateSize(player.maxHealth, player.health);
        }

        private int CalculateSize(int maxHealth, int health)
        {
            return health >= maxHealth ? 40 : (40 * health/maxHealth);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new Rectangle(new Point(posX, posY), new Size(sizeX, sizeY)));
        }
    }
}
