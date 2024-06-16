﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teamproject;

namespace teamproject
{
    class Board
    {
        internal static Board GameBoard
        {
            get;
            private set;
        }
        static Board()
        {
            GameBoard = new Board();
        }
        Board()
        {
        }
        int[,] board = new int[GameRule.BX, GameRule.BY];
        internal int this[int x, int y]
        {
            get
            {
                return board[x, y];
            }
        }
        internal bool MoveEnable(int bn, int tn, int x, int y)
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[bn, tn, xx, yy] != 0)
                    {
                        if (board[x + xx, y + yy] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        internal void Store(int bn, int turn, int x, int y)
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (((x + xx) >= 0) && (x + xx < GameRule.BX) && (y + yy >= 0) && (y + yy < GameRule.BY))
                    {
                        board[x + xx, y + yy] += BlockValue.bvals[bn, turn, xx, yy];
                    }
                }
            }
            int linesCleared = CheckLines(y + 3);
            if (linesCleared > 0)
            {
                Game.Singleton.AddScore(linesCleared);
            }
        }

        private int CheckLines(int y)
        {
            int yy = 0;
            int linesCleared = 0;
            for (yy = 0; (yy < 4); yy++)
            {
                if (y - yy < GameRule.BY)
                {
                    if (CheckLine(y - yy))
                    {
                        ClearLine(y - yy);
                        linesCleared++;
                        y++;
                    }
                }
            }
            return linesCleared;
        }

        private void ClearLine(int y)
        {
            for (; y > 0; y--)
            {
                for (int xx = 0; xx < GameRule.BX; xx++)
                {
                    board[xx, y] = board[xx, y - 1];
                }
            }
        }

        private bool CheckLine(int y)
        {
            for (int xx = 0; xx < GameRule.BX; xx++)
            {
                if (board[xx, y] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        internal void ClearBoard()
        {
            for (int xx = 0; xx < GameRule.BX; xx++)
            {
                for (int yy = 0; yy < GameRule.BY; yy++)
                {
                    board[xx, yy] = 0;
                }
            }
        }
    }
}

