using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Form
{
    public partial class Form1 : Form
    {
        static int point; // 점수 관리
        List<Fruit> fruits; // 동적 생성 과일 관리
        List<string[]> colors; // 과일 컬러 저장 컨테이너
        public Form1()
        {
            fruits = new List<Fruit>();
            colors = new List<string[]>();
            InitializeComponent();
            InitializeColors();
        }

        private void InitializeColors()
        {
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
            colors.Add(new string[] { "255", "255", "255" });
        }

        private void CombineFruit(int idx1, int idx2)
        {
            Fruit newFruit = new Fruit();
            newFruit.SetFruitID(fruits[idx1].GetFruitID() + 1);
        }

        private bool checkLength(int idx1, int idx2)
        {
            //과일간 거리 체크 함수
            double[] idx1Pos = fruits[idx1].GetPos();
            double[] idx2Pos = fruits[idx2].GetPos();
            double idx1Radius = fruits[idx1].GetRadius();
            double idx2Radius = fruits[idx2].GetRadius();
            double length = Math.Pow(idx1Pos[0], idx2Pos[0]) + Math.Pow(idx1Pos[1], idx2Pos[1]);
            if (length <= idx1Radius * idx1Radius + idx2Radius * idx2Radius)
            {

                return true;
            }
            return false;
        }

        private void CheckCollision()
        {
            if (fruits.Count > 2)
            {
                while (true)
                {
                    for (int i = 0; i < fruits.Count - 1; i++)
                    {
                        for (int j = i + 1; j < fruits.Count; j++)
                        {
                            if (fruits[i].GetFruitID() == fruits[j].GetFruitID() && checkLength(i, j))
                            {
                                CombineFruit(i, j);
                            }
                        }
                    }
                }
            }
        }

        private void fps_Tick(object sender, EventArgs e)
        {
            CheckCollision();
            pointlb.Text = point.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {

            }
            if (e.KeyCode == Keys.Right)
            {

            }
            if (e.KeyCode == Keys.Space)
            {

            }
        }

    }
    partial class Fruit
    {
        private FruitNum fruitID = FruitNum.cherry;
        private double[] pos = new double[2] { 400.0, 0.0 }; // 중점
        private double speed; // 속도
        private double radius; // 반지름
        private double mass; // 질량
        private double force; //힘

        public FruitNum GetFruitID()
        {
            return fruitID;
        }
        public double[] GetPos()
        {
            return pos;
        }
        public double GetRadius()
        {
            return radius;
        }
        public void SetFruitID(FruitNum newFruitID)
        {
            this.fruitID = newFruitID;
        }
        public void SetPos(double[] newPos)
        {
            this.pos = newPos;
        }
        public void SetRadius(double newRadius)
        {
            this.radius = newRadius;
        }
    }

    enum FruitNum
    {
        cherry = 1,
        strawberry,
        grape,
        orange,
        persimmon,
        apple,
        pear,
        peach,
        pineapple,
        melon,
        watermelon
    }
}
