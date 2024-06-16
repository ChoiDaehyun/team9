using System.Drawing;
using System.Drawing.Drawing2D;

namespace team9_wm
{
    public partial class SuikaGame : Form
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

        public SuikaGame()
        {
            fruits = new List<Fruit>();
            colors = new List<int[]>();
            nextFruit = new Queue<Fruit>();
            curFruit = new Fruit();
            point = 0;

            InitializeComponent();
            InitializeColors();
            ManageFruitQueue();

            //this.ControlBox = false;
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

        //curFruit관리
        private void ManagementCurFruit()
        {
            if (fruits.Count == 0 || CheckCurFruit())
            {
                curFruit = nextFruit.First();
                fruits.Add(curFruit);
                nextFruit.Dequeue();
                ManageFruitQueue();
            }
        }



        // 전체 과일 그리기
        private void DrawFruit()
        {
            DrawFruitInQueue();
            g = this.panel1.CreateGraphics();

            foreach (Fruit fruitinL in fruits)
            {
                myBrush = new SolidBrush(Color.FromArgb(fruitinL.GetColor()[0], fruitinL.GetColor()[1], fruitinL.GetColor()[2]));
                p = new Pen(Color.FromArgb(fruitinL.GetColor()[0], fruitinL.GetColor()[1], fruitinL.GetColor()[2]));
                g.DrawEllipse(p, fruitinL.GetPos()[0] - fruitinL.GetRadius(), fruitinL.GetPos()[1] - fruitinL.GetRadius(), 2 * fruitinL.GetRadius(), 2 * fruitinL.GetRadius());
                g.FillEllipse(myBrush, fruitinL.GetPos()[0] - fruitinL.GetRadius(), fruitinL.GetPos()[1] - fruitinL.GetRadius(), 2 * fruitinL.GetRadius(), 2 * fruitinL.GetRadius());
            }

            p = new Pen(Color.Black);
            p.DashStyle = DashStyle.DashDot;
            g.DrawLine(p, new Point(0, 93), new Point(603, 93));
        }


        // 조종중인 과일이 없으면 true , else false
        private bool CheckCurFruit()
        {
            foreach (Fruit fruitinL in fruits)
            {
                if (fruitinL.GetFruitState() != FruitState.StopState)
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
                EraseFruit(idx2);
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
            float lengthPow = ((idx1Pos[0] - idx2Pos[0] ) * (idx1Pos[0] - idx2Pos[0]))
                + ((idx1Pos[1] - idx2Pos[1]) * (idx1Pos[1] - idx2Pos[1]));

            if (lengthPow - 3200 < ((idx1Radius * idx1Radius) + (idx2Radius * idx2Radius)))
            {
                return true; //아래에 과일 있으면 true
            }

            return false;
        }

        private bool checkBottomLength(int idx1, int idx2)
        {
            float[] idx1Pos = fruits[idx1].GetPos();
            float[] idx2Pos = fruits[idx2].GetPos();
            int idx1Radius = fruits[idx1].GetRadius();
            int idx2Radius = fruits[idx2].GetRadius();
            float lengthPow = ((idx1Pos[0] - idx2Pos[0]) * (idx1Pos[0] - idx2Pos[0]))
                + ((idx1Pos[1] - idx2Pos[1]) * (idx1Pos[1] - idx2Pos[1]));

            if (FruitArrivedToBottom(fruits[idx1]) || (idx1Pos[1] < idx2Pos[1] && lengthPow - 3200 < ((idx1Radius * idx1Radius) + (idx2Radius * idx2Radius))))
            {
                return true; //아래에 과일 있으면 true
            }

            return false;
        }

        //현재 과일 바닥에 닿았는지 확인 바닥에 닿으면 true
        private bool CurFruitArrivedToBottom()
        {
            int bottom = this.panel1.Height;
            if (bottom - 1 >= curFruit.GetPos()[1] + curFruit.GetRadius())
            {
                return false;
            }
            return true;
        }

        private bool FruitArrivedToBottom(Fruit fruit)
        {
            int bottom = this.panel1.Height;
            if (bottom - 1 >= fruit.GetPos()[1] + fruit.GetRadius())
            {
                return false;
            }
            return true;
        }

        //현재 과일 다른 과일에 충돌
        private bool CurFruitCheckCollision()
        {
            if (fruits.Count < 2) { return false; }

            for (int i = 0; i < fruits.Count - 1; i++)
            {
                if (checkLength(i, fruits.Count - 1))
                {
                    return true;
                }
            }
            return false;
        }

        /*
        private bool FruitCheckCollision(int idx)
        {
            if (fruits.Count < 2) { return false; }

            for (int i = 0; i < fruits.Count; i++)
            {
                if (idx != i && checkLength(idx, i))
                {
                    return true;
                }
            }
            return false;
        }
        */

        private bool FruitBottomCheckCollision(int idx)
        {
            if (fruits.Count < 2) { return false; }

            for (int i = 0; i < fruits.Count; i++)
            {
                if (idx != i && checkBottomLength(idx, i))
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

        private void FallAnotherFruit(Fruit fruit, int idx)
        {
            bool collideCheck = !FruitArrivedToBottom(fruit) && !FruitBottomCheckCollision(idx);
            for (int i = 0; i < fruit.GetSpeed() && collideCheck; i++)
            {
                EraseFruitDown(idx);
                fruit.GoBottom();
                DrawFruit(fruit);
                collideCheck = !FruitArrivedToBottom(fruit) && !FruitBottomCheckCollision(idx);
            }
            
            if (!collideCheck)
            {
                fruit.SetToStopState();
                fruit.SetSpeed(1);
            }
        }
        
        
        private void CheckAnotherFruit() {
            bool collideCheck = false;
            if (fruits.Count <= 2)
            {
                return;
            }
            for (int i = 0; i < fruits.Count - 1; i++)
            {
                for (int j = 0; j < fruits.Count - 1; j++)
                {
                    if (i != j && checkBottomLength(i, j)) {
                        collideCheck = true;
                        break;
                    }       
                }

                if (!collideCheck)
                {
                    fruits[i].SetToNeedFallState();
                    fruits[i].IncreaseSpeed();
                    FallAnotherFruit(fruits[i] , i);
                }
                else {
                    collideCheck = false;
                }
            }
        }
        
        private void EraseFruit(int idx)
        {
            myBrush = new SolidBrush(Color.White);
            p = new Pen(Color.White);
            g.DrawEllipse(p, fruits[idx].GetPos()[0] - fruits[idx].GetRadius(), fruits[idx].GetPos()[1] - fruits[idx].GetRadius(), 2 * fruits[idx].GetRadius(), 2 * fruits[idx].GetRadius());
            g.FillEllipse(myBrush, fruits[idx].GetPos()[0] - fruits[idx].GetRadius(), fruits[idx].GetPos()[1] - fruits[idx].GetRadius(), 2 * fruits[idx].GetRadius(), 2 * fruits[idx].GetRadius());
        }

        private void EraseFruitDown(int idx)
        {
            p = new Pen(Color.White);
            p.Width = 5;
            g.DrawEllipse(p, fruits[idx].GetPos()[0] - fruits[idx].GetRadius(), fruits[idx].GetPos()[1] - fruits[idx].GetRadius(), 2 * fruits[idx].GetRadius(), 2 * fruits[idx].GetRadius());
        }

        private void EraseCurFruitDown()
        {
            p = new Pen(Color.White);
            p.Width = 5;
            g.DrawEllipse(p, curFruit.GetPos()[0] - curFruit.GetRadius(), curFruit.GetPos()[1] - curFruit.GetRadius(), 2 * curFruit.GetRadius(), 2 * curFruit.GetRadius());
        }

        private void EraseCurFruitSide()
        {
            p = new Pen(Color.White);
            p.Width = 5;
            g.DrawEllipse(p, curFruit.GetPos()[0] - curFruit.GetRadius(), curFruit.GetPos()[1] - curFruit.GetRadius(), 2 * curFruit.GetRadius(), 2 * curFruit.GetRadius());
        }

        private void DrawCurFruit()
        {
            myBrush = new SolidBrush(Color.FromArgb(curFruit.GetColor()[0], curFruit.GetColor()[1], curFruit.GetColor()[2]));
            p = new Pen(Color.White);
            g.DrawEllipse(p, curFruit.GetPos()[0] - curFruit.GetRadius(), curFruit.GetPos()[1] - curFruit.GetRadius(), 2 * curFruit.GetRadius(), 2 * curFruit.GetRadius());
            g.FillEllipse(myBrush, curFruit.GetPos()[0] - curFruit.GetRadius(), curFruit.GetPos()[1] - curFruit.GetRadius(), 2 * curFruit.GetRadius(), 2 * curFruit.GetRadius());
        }


        private void DrawFruit(Fruit fruit)
        {
            myBrush = new SolidBrush(Color.FromArgb(fruit.GetColor()[0], fruit.GetColor()[1], fruit.GetColor()[2]));
            p = new Pen(Color.White);
            g.DrawEllipse(p, fruit.GetPos()[0] - fruit.GetRadius(), fruit.GetPos()[1] - fruit.GetRadius(), 2 * fruit.GetRadius(), 2 * fruit.GetRadius());
            g.FillEllipse(myBrush, fruit.GetPos()[0] - fruit.GetRadius(), fruit.GetPos()[1] - fruit.GetRadius(), 2 * fruit.GetRadius(), 2 * fruit.GetRadius());
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

        private void curFruitDown() {
            bool collideCheck = !CurFruitArrivedToBottom() && !CurFruitCheckCollision();
            for (int i = 0; i < curFruit.GetSpeed() && collideCheck; i++) {
                EraseCurFruitDown();
                curFruit.GoBottom();
                DrawCurFruit();
                collideCheck = !CurFruitArrivedToBottom() && !CurFruitCheckCollision();
            }
            if (!collideCheck)
            {
                curFruit.SetToStopState();
                curFruit.SetSpeed(1);
                point += (int)curFruit.GetFruitID() + 1;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            float curLeft = curFruit.GetPos()[0] - curFruit.GetRadius();
            float curRight = curFruit.GetPos()[0] + curFruit.GetRadius();
            int leftBound = 0;
            int rightBound = this.panel1.Width;

            if (curLeft - 5 >= leftBound)
            {
                if (e.KeyCode == Keys.Left && curFruit.GetFruitState() == FruitState.CurFruitState)
                {
                    EraseCurFruitSide();
                    curFruit.GoLeft();
                }
            }
            if (curRight + 5 <= rightBound)
            {
                if (e.KeyCode == Keys.Right && curFruit.GetFruitState() == FruitState.CurFruitState)
                {
                    EraseCurFruitSide();
                    curFruit.GoRight();
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                curFruit.SetToFallState();
            }
        }

        private void fps_Tick(object sender, EventArgs e)
        {
            if (curFruit.GetFruitState() == FruitState.FallState) {
                EraseCurFruitDown();
                curFruitDown();
                curFruit.IncreaseSpeed();
            }

            
            DrawFruit();
            ManagementCurFruit();
            CheckCollision();
            CheckAnotherFruit(); // 다른 과일이 충돌로 인해 떠있을 경우
            pointlb.Text = point.ToString();

            GameOver();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer
| ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

    }

}

/*
    현재 이슈
    1. collide 정확하게 -> checkLength를 좀 살펴보고
    2. 충돌후 붕 뜨는거 -> queue에서 뜬거 확인해서 중력 재조정
    3. line 지워지는거  -> curFruit 위치가 일정 이하로 가면 다시 그리자
 */