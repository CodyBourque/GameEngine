using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Monster
    {
        public int x, y, size, speed;
        public Image[] monster;

        public Monster(int _x, int _y, int _size, int _speed, Image[] _monster)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            monster = _monster;
        }

        public void move(Monster monster, int direction)
        { 
            if (direction == 0)
            {
                monster.x += speed;
            }
            if (direction == 1)
            {
                monster.x -= speed;
            }
            if (direction == 2)
            {
                monster.y += speed;
            }
            if (direction == 3)
            {
                monster.y -= speed;
            }
        }


        public bool collision(Monster monster, Bullet bullet)
        {
            Rectangle monsterRect = new Rectangle(monster.x, monster.y, monster.size, monster.size);
            Rectangle pew = new Rectangle(bullet.x, bullet.y, bullet.size, bullet.size);

            if (monsterRect.IntersectsWith(pew))
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
