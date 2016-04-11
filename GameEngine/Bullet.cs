using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Bullet
    {
        public int x, y, size, speed;
        public string direction;

        public Bullet(int _x, int _y, int _size, int _speed, string _direction)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;
        }

        public void move(Bullet bullet)
        {
            if (bullet.direction == "left")
            {
                bullet.x -= bullet.speed;
            }
            if (bullet.direction == "right")
            {
                bullet.x += speed;
            }
            if (bullet.direction == "up")
            {
                bullet.y -= speed;
            }
            if (bullet.direction == "down")
            {
                bullet.y += speed;
            }
        }
    }
}
