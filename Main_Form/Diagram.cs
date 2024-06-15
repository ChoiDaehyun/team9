using Main_Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamproject
{
    internal class Diagram
    {
        internal int X
        {
            get;
            private set;
        }
        internal int Y
        {
            get;
            private set;
        }
        internal int Turn
        {
            get;
            private set;
        }
        internal int BlockNum
        {
            get;
            private set;
        }
        internal Diagram()
        {
            ReSet();
        }
        internal void ReSet()
        {
            Random rand = new Random();
            X = GameRule.SX;
            Y = GameRule.SY;
            Turn = rand.Next() % 4;
            BlockNum = rand.Next() % 7;
        }
        internal void MoveLeft()
        {
            X--;
        }
        internal void MoveRight()
        {
            X++;
        }
        internal void MoveDown()
        {
            Y++;
        }
        internal void MoveTurn()
        {
            Turn = (Turn + 1) % 4;
        }
    }
}


