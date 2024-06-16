using Main_Form;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormproject;
namespace teamproject
{
    class Game
    {
        Diagram now;
        Board gboard = Board.GameBoard;
        internal Point NowPosition
        {
            get
            {
                return new Point(now.X, now.Y);
            }
        }
        internal int BlockNum
        {
            get
            {
                return now.BlockNum;
            }
        }
        internal int Turn
        {
            get
            {
                return now.Turn;
            }
        }

        internal static Game Singleton
        {
            get;
            private set;
        }
        internal int this[int x, int y]
        {
            get
            {
                return gboard[x, y];
            }
        }

        internal int Score { get; private set; }

        static Game()
        {
            Singleton = new Game();
        }
        Game()
        {
            now = new Diagram();
            Score = 0;
        }

        internal bool MoveLeft()
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[now.BlockNum, Turn, xx, yy] != 0)
                    {
                        if (now.X + xx <= 0)
                        {
                            return false;
                        }
                    }
                }
            }

            if (gboard.MoveEnable(now.BlockNum, Turn, now.X - 1, now.Y))
            {
                now.MoveLeft();
                return true;
            }
            return false;
        }

        internal bool MoveRight()
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[now.BlockNum, Turn, xx, yy] != 0)
                    {
                        if ((now.X + xx + 1) >= GameRule.BX)
                        {
                            return false;
                        }
                    }
                }
            }
            if (gboard.MoveEnable(now.BlockNum, Turn, now.X + 1, now.Y))
            {
                now.MoveRight();
                return true;
            }
            return false;
        }

        internal bool MoveDown()
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[now.BlockNum, Turn, xx, yy] != 0)
                    {
                        if ((now.Y + yy + 1) >= GameRule.BY)
                        {
                            gboard.Store(now.BlockNum, Turn, now.X, now.Y);
                            return false;
                        }
                    }
                }
            }
            if (gboard.MoveEnable(now.BlockNum, Turn, now.X, now.Y + 1))
            {
                now.MoveDown();
                return true;
            }
            gboard.Store(now.BlockNum, Turn, now.X, now.Y);
            return false;
        }

        internal bool MoveTurn()
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[now.BlockNum, (Turn + 1) % 4, xx, yy] != 0)
                    {
                        if (((now.X + xx) < 0) || ((now.X + xx) >= GameRule.BX) || ((now.Y + yy) >= GameRule.BY))
                        {
                            return false;
                        }
                    }
                }
            }
            if (gboard.MoveEnable(now.BlockNum, (Turn + 1) % 4, now.X, now.Y))
            {
                now.MoveTurn();
                return true;
            }
            return false;
        }

        internal bool Next()
        {
            now.ReSet();
            return gboard.MoveEnable(now.BlockNum, Turn, now.X, now.Y);
        }

        internal void ReStart()
        {
            gboard.ClearBoard();
        }

        internal void AddScore(int linesCleared)
        {
            Score += linesCleared * 1000;
        }
    }
}
