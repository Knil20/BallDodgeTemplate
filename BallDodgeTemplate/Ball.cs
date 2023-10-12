using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDodgeTemplate
{
    internal class Ball
    {
        public int size = 10;
        public int x, y, xSpeed, ySpeed;

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= xSpeed;
            }
            else if (direction == "right")
            {
                x += xSpeed;
            }

            if (direction == "up")
            {
                y -= ySpeed;
            }
            else if (direction == "down")
            {
                y += ySpeed;
            }
        }

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;

            if (x < 0 || x > 600 - size)
            {
                xSpeed *= -1;
            }

            if (y < 0 || y > 500 - size)
            {
                ySpeed *= -1;
            }
        }
    }
}
