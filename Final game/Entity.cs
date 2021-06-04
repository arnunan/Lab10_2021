using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Final_game
{
    public class Entity
    {
        #region Fields
        public int posX, posY, centreX, centreY;

        public int sizeX, sizeY;

        public int a; 
        public int speedX, speedY;

        public int dx, dy;

        public int idleFrames, runFrames, attackFrames, deathFrames, hurtFrames;
        public int currentAnimation, currentFrame, frameLimit;

        public bool goUp, goDown, goLeft, goRight;

        public bool Attack, getDamage, isOnEarth;

        public bool flip;

        public int health;

        private readonly Random r = new Random();

        public Image spriteSheet;

        #endregion
        public Entity(int posX, int posY, int sizeX, int sizeY, int health, Image spriteSheet,  int idleFrames = 1, int runFrames = 1, int attackFrames = 1, int deathFrames = 1, int hurtFrames = 4)
        {
            this.posX = posX;
            this.posY = posY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.idleFrames = idleFrames;
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.deathFrames = deathFrames;
            this.hurtFrames = hurtFrames;
            this.health = health;
            this.spriteSheet = spriteSheet;

            currentAnimation = 0;
            currentFrame = 0;
            frameLimit = idleFrames;
            flip = true;
            a = 1;
            speedX = 3;
        }

        public void PlayAnimation(Graphics g)
        {
            currentFrame %= frameLimit;

            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(sizeX, sizeY)),
                        sizeX * currentFrame, sizeY * currentAnimation, sizeX, sizeY, GraphicsUnit.Pixel);

            currentFrame++;
        }

        public void SetAniConf(int curAni)
        {
            if (curAni == 0 || curAni == 6)
                frameLimit = idleFrames;
            if (curAni == 1 || curAni == 7)
                frameLimit = runFrames;
            if (curAni == 2 || curAni == 8)
                frameLimit = attackFrames;
            if (curAni == 3 || curAni == 9)
                frameLimit = 1;
            if (curAni == 4 || curAni == 10)
                frameLimit = deathFrames;
            if (curAni == 5 || curAni == 11)
                frameLimit = hurtFrames;

            currentAnimation = flip ? curAni % 6 : curAni % 6 + 6;
        }

        public void Stop()
        {
            dx = 0;
            dy = 0;
            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            Attack = false;
            speedX = 0;
            speedY = 0;
        }

        public bool NearDoor(List<Environment> doors)
        {
            foreach (var e in doors)
            {
                if (Math.Abs(posX + sizeX / 2 - e.posX - e.sizeX / 2) < 20 && Math.Abs(posY + sizeY / 2 - e.posY - e.sizeY / 2) < 10)
                    return true;
            }
            return false;
        }

        public bool ContactEnemy(Entity enemy)
        {
            return Math.Abs(posX + sizeX/2 - enemy.posX - enemy.sizeX/2) < 25 && Math.Abs(posY + sizeY/2 - enemy.posY - enemy.sizeY/2) < 10;
        }

        public void GoTo(Environment door)
        {
            posX = door.posX;
            posY = door.posY;
        }

        public void Phisics(List<Environment> Boundaries)
        {
            dy += a;
            GoingDown(Boundaries);

            if (goUp)
            {
                isOnEarth = false;
                speedY += a;
                GoingUp(Boundaries);
                posY += speedY;
            }

            if (goRight)
            {
                dx = 4;
                GoingRight(Boundaries);
                posX += dx;
            }

            if (goLeft)
            {
                dx = -4;
                GoingLeft(Boundaries);
                posX += dx;
            }

            posY += dy;
        }

        public void Moving()
        {
            var jump = r.Next(0, 10);
            goUp = jump > 7;
            speedY = goUp ? -10 : 0;
        }

        public void GoingUp(List<Environment> boundaries)
        {
            if (!isOnEarth)
            {
                foreach (var el in boundaries)
                {
                    if (posY + 4 > el.posY + el.sizeY && posY + speedY + 4 <= el.posY + el.sizeY && posX + 4 * sizeX / 5 > el.posX && posX + 2 * sizeX / 5 < el.posX + el.sizeX)
                    {
                        speedY = el.posY + el.sizeY - (posY + 3);
                        
                    }
                }
            }
            if (speedY > 0) speedY = 0;
        }

        public void GoingDown(List<Environment> boundaries)
        {
            dy += a;
            foreach (var el in boundaries)
            {
                if (posY + sizeY  < el.posY && posY + sizeY  + dy >= el.posY && posX + 4 * sizeX / 5 > el.posX && posX + 2 * sizeX / 5 < el.posX + el.sizeX)
                { 
                    dy = el.posY - (posY + sizeY ) - 1;
                    isOnEarth = true;
                }
            }
            if (dy > 21)
                dy = 21;
        }

        public void GoingRight(List<Environment> boundaries)
        {
            foreach (var el in boundaries)
            {
                if (posX + 4 * sizeX / 5 < el.posX && posX + 4 * sizeX / 5 + dx >= el.posX && posY + sizeY - 3 > el.posY && posY + 8 < el.posY + el.sizeY)
                {
                    dx = el.posX - (posX + 4 * sizeX / 5) - 1;
                }
            }
        }

        public void GoingLeft(List<Environment> boundaries)
        {
            foreach (var el in boundaries)
            {
                if (posX + 2 * sizeX / 5 > el.posX + el.sizeX && posX + 2 * sizeX / 5 + dx <= el.posX + el.sizeX && posY + sizeY - 3 > el.posY && posY + 8 < el.posY + el.sizeY)
                {
                    dx = el.posX + el.sizeX - (posX + 2 * sizeX / 5) + 1;
                }
            }
        }

        public bool BotAttack()
        {
            var rnd = r.Next(0,10);
            Attack = rnd > 8;
            return Attack;
        }

        public void GetDamage(bool side, List<Environment> boundaries, int damage)
        {
            health -= damage;
            SetAniConf(5);
            if (side)
            {
                dx = 17;
                dy = -5;
                GoingRight(boundaries);
                GoingUp(boundaries);
                posX += dx;
                posY += dy;
            }
            else
            {
                dx = -17;
                dy = -5;
                GoingRight(boundaries);
                GoingUp(boundaries);
                posX += dx;
                posY += dy;
            }
        }
    }
}
