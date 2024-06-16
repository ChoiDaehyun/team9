using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suika_Game
{

    enum FruitNum
    {
        red,
        orange,
        yellow,
        green,
        blue,
        indigo,
        purple,
        black,
    }

    enum FruitState
    {
        CurFruitState,
        FallState,
        StopState,
        NeedFallState,
    }

    internal class Fruit
    {
        private FruitState fruitState = FruitState.CurFruitState;
        private FruitNum fruitID = FruitNum.red;
        private int[] color = new int[3];
        private float[] pos = new float[2] { 320, 40 }; // 중점
        private int speed = 1; // 속도
        private int radius = 40; // 반지름
        //private int mass; // 질량
        //private int force; //힘

        public FruitNum GetFruitID()
        {
            return fruitID;
        }
        public int[] GetColor()
        {
            return color;
        }
        public float[] GetPos()
        {
            return pos;
        }
        public int GetRadius()
        {
            return radius;
        }

        public FruitState GetFruitState()
        {
            return fruitState;
        }

        public int GetSpeed()
        {
            return speed;
        }
        public void IncreaseSpeed()
        {
            speed++;
        }
        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }
        public void SetToFallState()
        {
            fruitState = FruitState.FallState;
        }
        public void SetToStopState()
        {
            fruitState = FruitState.StopState;
        }
        public void SetToNeedFallState()
        {
            fruitState = FruitState.StopState;
        }
        public void SetFruitID(FruitNum newFruitID)
        {
            this.fruitID = newFruitID;
        }
        public void SetColor(int[] newColor)
        {
            this.color = newColor;
        }
        public void SetPos(float[] newPos)
        {
            this.pos = newPos;
        }
        public void GoLeft()
        {
            this.pos[0] -= 5;
        }
        public void GoRight()
        {
            this.pos[0] += 5;
        }
        public void GoBottom()
        {
            this.pos[1]++;
        }
        public void SetRadius(int newRadius)
        {
            this.radius = newRadius;
        }
    }

}
