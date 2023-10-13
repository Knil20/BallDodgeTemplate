using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial class GameScreen : UserControl
    {
        Player hero;
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush limeBrush = new SolidBrush(Color.Lime);
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        List<Ball> balls = new List<Ball>();

        public GameScreen()
        {
            InitializeComponent();


            hero = new Player(100, 100, 10, 10);
            Ball enemyBall;
            Random randGen = new Random();

            for (int i = 0; i < 10; i++)
            {
                int x = randGen.Next(50, 400);
                int y = randGen.Next(50, 400);

                int xSpeed = randGen.Next(-10, 10);
                int ySpeed = randGen.Next(-10, 10);
                enemyBall = new Ball(x, y, xSpeed, ySpeed);
                balls.Add(enemyBall);
            }




        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move hero
            if (leftArrowDown && hero.x > 0)
            {
                hero.Move("left");
            }
            else if (rightArrowDown && hero.x < this.Width - hero.width)
            {
                hero.Move("right");
            }

            if (upArrowDown && hero.y > 0)
            {
                hero.Move("up");
            }
            else if (downArrowDown && hero.y < this.Height - hero.height)
            {
                hero.Move("down");
            }

            //move enemies and check for collision
            foreach (Ball b in balls)
            {
                b.Move();
                b.Collision(hero);
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //show health
            healthLabel.Text = hero.health + "";

            //draw hero
            e.Graphics.FillRectangle(limeBrush, hero.x, hero.y, hero.width, hero.height);

            //draw enemies
            foreach (Ball b in balls)
            {
                e.Graphics.FillEllipse(whiteBrush, b.x, b.y, b.size, b.size);
            }


        }
    }
}
