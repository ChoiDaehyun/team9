using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Main_Form
{
    public partial class Form1 : Form
    {
        static int point = 0; // 점수 관리
        List<Fruit> fruits; // 동적 생성 과일 관리
        List<int[]> colors; // 과일 컬러 저장 컨테이너
        Queue<Fruit> nextFruit; // 다음 과일 저장 큐
        Fruit curFruit;
        Random rand = new Random();

        Graphics g;
        SolidBrush myBrush;
        Pen p;

        public Form1()
        {
            fruits = new List<Fruit>();
            colors = new List<int[]>();
            nextFruit = new Queue<Fruit>();
            curFruit = new Fruit();

            InitializeComponent();
            InitializeColors();
            ManageFruitQueue();

            this.ControlBox = false;
            fps.Start();

        }

        private void InitializeColors()
        {
            colors.Add(new int[] { 255, 0, 0 }); // Red
            colors.Add(new int[] { 255, 128, 0 }); // Orange
            colors.Add(new int[] { 255, 255, 0 }); // Yellow
            colors.Add(new int[] { 0, 128, 0 }); // Green
            colors.Add(new int[] { 0, 0, 255 }); // Blue
            colors.Add(new int[] { 0, 0, 128 }); // Indigo
            colors.Add(new int[] { 128, 0, 128 }); // Purple
            colors.Add(new int[] { 0, 0, 0 }); // Black
        }

        private void ManageFruitQueue()
        {
            while (nextFruit.Count < 5)
            {
                int newFruitID = rand.Next(0, 4);
                Fruit fruit = new Fruit();
                fruit.SetFruitID((FruitNum)newFruitID);
                fruit.SetColor(colors[newFruitID]);
                nextFruit.Enqueue(fruit);
            }
        }

        // 전체 과일 그리기

        private void DrawFruit()
        {
            panel1.Controls.Clear();

            if (fruits.Count == 0 || CheckCurFruit())
            {
                curFruit = nextFruit.First();
                fruits.Add(curFruit);
                nextFruit.Dequeue();
                ManageFruitQueue();
            }


            g = this.panel1.CreateGraphics();

            foreach (Fruit fruitinL in fruits)
            {
                myBrush = new SolidBrush(Color.FromArgb(fruitinL.GetColor()[0], fruitinL.GetColor()[1], fruitinL.GetColor()[2]));
                p = new Pen(Color.Black);
                g.DrawEllipse(p, fruitinL.GetPos()[0] - fruitinL.GetRadius(), fruitinL.GetPos()[1] - fruitinL.GetRadius(), 2 * fruitinL.GetRadius(), 2 * fruitinL.GetRadius());
                g.FillEllipse(myBrush, fruitinL.GetPos()[0] - fruitinL.GetRadius(), fruitinL.GetPos()[1] - fruitinL.GetRadius(), 2 * fruitinL.GetRadius(), 2 * fruitinL.GetRadius());

            }

            DrawFruitInQueue();
        }


        // 조종중인 과일이 없으면 true , else false
        private bool CheckCurFruit()
        {
            foreach (Fruit fruitinL in fruits)
            {
                if (!fruitinL.GetCollide())
                {
                    return false;
                }
            }
            return true;
        }

        // 다음 5개의 과일을 보여줌
        private void DrawFruitInQueue()
        {
            g = this.panel2.CreateGraphics();
            int i = 0;
            foreach (Fruit fruitInQ in nextFruit)
            {
                myBrush = new SolidBrush(Color.FromArgb(fruitInQ.GetColor()[0], fruitInQ.GetColor()[1], fruitInQ.GetColor()[2]));
                p = new Pen(Color.Black);
                g.DrawEllipse(p, 0, 80 * i, 80, 80);
                g.FillEllipse(myBrush, 0, 80 * i, 80, 80);
                i++;
            }
        }


        //합쳐짐 처리
        private void CombineFruit(int idx1, int idx2)
        {
            int curid = (int)fruits[idx1].GetFruitID();

            if (fruits[idx1].GetFruitID() != FruitNum.black)
            {
                ++curid;
                fruits[idx1].SetFruitID((FruitNum)curid);
                fruits[idx1].SetColor(colors[curid]);
                fruits.Remove(fruits[idx2]);
                point += 2 * curid;
            }
        }

        //과일간 거리 체크 함수 충돌시 true
        private bool checkLength(int idx1, int idx2)
        {

            float[] idx1Pos = fruits[idx1].GetPos();
            float[] idx2Pos = fruits[idx2].GetPos();
            int idx1Radius = fruits[idx1].GetRadius();
            int idx2Radius = fruits[idx2].GetRadius();
            float lengthPow = (idx1Pos[0] - idx2Pos[0]) * (idx1Pos[0] - idx2Pos[0]) + (idx1Pos[1] - idx2Pos[1]) * (idx1Pos[1] - idx2Pos[1]);
            if (lengthPow <= idx1Radius * idx1Radius + idx2Radius * idx2Radius)
            {
                return true;
            }
            return false;
        }

        //현재 과일 바닥에 닿았는지 확인 바닥에 닿으면 true
        private bool CurFruitArrivedToBottom()
        {
            int bottom = this.panel1.Height;
            if (bottom >= curFruit.GetPos()[1] + curFruit.GetRadius())
            {
                return false;
            }
            return true;
        }

        //현재 과일 다른 과일에 충돌
        private bool CurFruitCheckCollision()
        {
            if (fruits.Count == 0) { return false; }

            for (int i = 0; i < fruits.Count - 1; i++)
            {
                if (checkLength(i, fruits.Count - 1))
                {
                    return true;
                }
            }
            return false;
        }

        //과일 충돌시 Combine처리
        private void CheckCollision()
        {
            if (fruits.Count < 2)
            {
                return;
            }

            for (int i = 0; i < fruits.Count - 1; i++)
            {
                for (int j = i + 1; j < fruits.Count; j++)
                {
                    if (checkLength(i, j) && fruits[i].GetFruitID() == fruits[j].GetFruitID())
                    {
                        CombineFruit(i, j);
                    }
                }
            }
        }

        private void GameOver()
        {
            if (fruits.Count <= 5)
            {
                return;
            }

            for (int i = 0; i < fruits.Count - 1; i++)
            {
                if (fruits[i].GetPos()[1] - fruits[i].GetRadius() < 100)
                {
                    this.Close();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            float curLeft = curFruit.GetPos()[0] - curFruit.GetRadius();
            float curRight = curFruit.GetPos()[0] + curFruit.GetRadius();
            float curBottom = curFruit.GetPos()[1] + curFruit.GetRadius();
            int leftBound = 0;
            int rightBound = this.panel1.Width;

            if (curLeft > leftBound)
            {
                if (e.KeyCode == Keys.Left)
                {
                    curFruit.GoLeft();
                }
            }
            if (curRight < rightBound)
            {
                if (e.KeyCode == Keys.Right)
                {
                    curFruit.GoRight();
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                while (!CurFruitArrivedToBottom() && !CurFruitCheckCollision())
                {
                    curFruit.GoBottom();
                }
                curFruit.SetCollide();
                point += (int)curFruit.GetFruitID() + 1;
            }
        }

        private void fps_Tick(object sender, EventArgs e)
        {
            DrawFruit();
            CheckCollision();
            pointlb.Text = point.ToString();

            this.panel1.Refresh();
            GameOver();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
