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
        Ball hero = new Ball(100, 100, 10, 10);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        List<Ball> balls = new List<Ball>();

        public GameScreen()
        {
            InitializeComponent();
            Ball enemyBall = new Ball(150, 100, 10, 10);
            balls.Add(enemyBall);

            enemyBall = new Ball(250, 250, -10, 10);
            balls.Add(enemyBall);

            enemyBall = new Ball(400, 150, 10, -10);
            balls.Add(enemyBall);

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
            if(leftArrowDown && hero.x > 0)
            {
                hero.Move("left");
            }
            else if (rightArrowDown && hero.x < this.Width - hero.size)
            {
                hero.Move("right");
            }

            if (upArrowDown && hero.y > 0)
            {
                hero.Move("up");
            }
            else if(downArrowDown && hero.y < this.Height - hero.size)
            {
                hero.Move("down");
            }

            //move enemies
            foreach(Ball b in balls)
            {
                b.Move();
            }
         

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(whiteBrush, hero.x, hero.y, hero.size, hero.size);

            foreach (Ball b in balls)
            {
                e.Graphics.FillEllipse(whiteBrush, b.x, b.y, b.size, b.size);
            }
        }
    }
}
