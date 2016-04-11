using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine
{
    public partial class gameScreen : UserControl
    {
        Random rnd = new Random();
        int heroX = 25;
        int heroY = 25;
        int size = 10;
        int speed = 5;
        int monsterTime = 0;
        int maxMonster = 10;
        string direction;
        Image[] pImage = new Image[4];
        Image[] monsterImg = new Image[4];
        List<Monster> mList = new List<Monster>();
        List<Bullet> bList = new List<Bullet>();
        Hero h = new Hero();

        SolidBrush enemytestb = new SolidBrush(Color.Red);
        Pen enemytestp = new Pen(Color.Red);
        SolidBrush playertest = new SolidBrush(Color.White);
        Pen playertestp = new Pen(Color.White);
        SolidBrush bullettest = new SolidBrush(Color.Blue);
        Pen bullettestp = new Pen(Color.Blue);
   
        bool leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown;

        public gameScreen()
        {
            InitializeComponent();
        }

        private void gameScreen_Load(object sender, EventArgs e)
        {
            Focus();

            h.x = heroX;
            h.y = heroY;
            h.speed = speed;
            h.size = size;

            pImage[0] = Properties.Resources.sans0;
            pImage[1] = Properties.Resources.sans1;
            pImage[2] = Properties.Resources.sans2;
            pImage[3] = Properties.Resources.sans3;

            monsterImg[0] = Properties.Resources._0;
            monsterImg[1] = Properties.Resources._1;
            monsterImg[2] = Properties.Resources._2;
            monsterImg[3] = Properties.Resources._3;

            Monster m = new Monster(rnd.Next(100, 476), rnd.Next(100, 476), size, speed, monsterImg);
            mList.Add(m);
        }

        private void gameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    leftArrowDown = true;
                    break;
                case Keys.S:
                    downArrowDown = true;
                    break;
                case Keys.D:
                    rightArrowDown = true;
                    break;
                case Keys.W:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        void gameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    leftArrowDown = false;
                    direction = "left";
                    break;
                case Keys.S:
                    downArrowDown = false;
                    direction = "down";
                    break;
                case Keys.D:
                    rightArrowDown = false;
                    direction = "right";
                    break;
                case Keys.W:
                    upArrowDown = false;
                    direction = "up";
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region character movement
                if (leftArrowDown == true)
                {
                    h.move(h, "left");
                    direction = "left";
                    Refresh();
                }
                if (upArrowDown == true)
                {
                    h.move(h, "up");
                    direction = "up";
                    Refresh();
                }
                if (rightArrowDown == true)
                {
                    h.move(h, "right");
                    direction = "right";
                    Refresh();
                }
                if (downArrowDown == true)
                {
                    h.move(h, "down");
                    direction = "down";
                    Refresh();
                }

            #endregion

            #region player collision

            foreach(Monster m in mList)
            {
                if (h.collision(h, m))
                {
                    GameOver();
                }
            }

            #endregion

            #region new monster

            if (monsterTime == 0 && mList.Count() != maxMonster)
            {
                Monster m = new Monster(rnd.Next(15, (this.Width - 15)), rnd.Next(15, this.Height - 15), size, speed, monsterImg);
                mList.Add(m);
                monsterTime = 30;
                Refresh();
            }
            else
            {
                monsterTime--;
            }
            
            #endregion 

            #region monster stuff
            for (int i = 0; i < 5; i++)
            {
                foreach (Monster m in mList)
                {
                    int direction = rnd.Next(0, 4);
                    if (direction == 0)
                    {
                        m.move(m, 0);
                    }
                    if (direction == 1)
                    {
                        m.move(m, 1);
                    }
                    if (direction == 2)
                    {
                        m.move(m, 2);
                    }
                    if (direction == 3)
                    {
                        m.move(m, 3);
                    }
                }
            }

            #endregion

            #region monster dead

            foreach (Bullet b in bList)
            {
                foreach (Monster m in mList)
                {
                    if (m.collision(m, b) == true)
                    {
                        mList.Remove(m);
                        bList.Remove(b);
                        Refresh();
                    }
                }
            }

            #endregion

            #region bullets

            if (spaceDown && bList.Count() == 0)
            {
                if (direction == "up")
                {
                    Bullet b = new Bullet(h.x, h.y, 2, 20, "up");
                    bList.Add(b);
                    b.move(b);
                }
                if (direction == "right")
                {
                    Bullet b = new Bullet(h.x, h.y, 2, 20, "right");
                    bList.Add(b);
                    b.move(b);
                }
                if (direction == "left")
                {
                    Bullet b = new Bullet(h.x, h.y, 2, 20, "left");
                    bList.Add(b);
                    b.move(b);
                }
                if (direction == "down")
                {
                    Bullet b = new Bullet(h.x, h.y, 2, 20, "down");
                    bList.Add(b);
                    b.move(b);
                }
            }

            foreach (Bullet b in bList)
            {
                if (b.x > this.Width)
                {
                    bList.Remove(b);
                }
                if (b.y > this.Height)
                {
                    bList.Remove(b);
                }
            }
            #endregion

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Monster m in mList)
            {
                e.Graphics.DrawRectangle(enemytestp, m.x, m.y, size, size);
                e.Graphics.FillRectangle(enemytestb, m.x, m.y, size, size);
            }
            foreach (Bullet b in bList)
            {
                e.Graphics.DrawRectangle(bullettestp, b.x, b.y, b.size, b.size);
                e.Graphics.FillRectangle(bullettest, b.x, b.y, b.size, b.size);
            }
                e.Graphics.DrawRectangle(playertestp, h.x, h.y, size, size);
                e.Graphics.FillRectangle(playertest, h.x, h.y, size, size);
        }

        private void GameOver()
        {
            gameOver go = new gameOver();
            Controls.Add(go);
            go.BringToFront();
        }
    }
    }

