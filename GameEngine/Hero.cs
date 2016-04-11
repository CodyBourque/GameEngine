using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Hero
    {
        public int x, y, size, speed;
        public Image[] character;

        public Hero(int _x, int _y, int _size, int _speed, Image[] _character)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            character = _character;
        }

        public Hero()
        {
        }

        public void move(Hero hero, string direction)
        {
            if (direction == "left")
            {
                hero.x -= speed;
            }
            if (direction == "right")
            {
                hero.x += speed;
            }
            if (direction == "up")
            {
                hero.y -= speed;
            }
            if (direction == "down")
            {
                hero.y += speed;
            }
        }

        public bool collision(Hero hero, Monster monster)
        {
            Rectangle heroRect = new Rectangle(hero.x, hero.y, hero.size, hero.size);
            Rectangle monsterRect = new Rectangle(monster.x, monster.y, monster.size, monster.size);

            if (heroRect.IntersectsWith(monsterRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
