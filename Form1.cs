using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace study {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            InitializeCards();
            InitializeBtn();
        }
        int[] cards = new int[52];
        Stack<CustomBtn> pair = new Stack<CustomBtn>();
        private CustomBtn pre_Btn;

        private int score = 0;

        private int counta = 1;
        private int countb = 2;
        private int countc = 3;
        private int countd = 4;
        private int counte = 5;
        private int countf = 6;
        private int countg = 7;

        private void InitializeCards() {
            this.SuspendLayout();
            for (int i = 0; i < 4; i++) {
                for (int j = 1; j < 14; j++) {
                    cards[i * 13 + j - 1] = j;
                }
            }
        }
        public void InitializeBtn() {
            a.setdata(cards[0]);
            a.setleft(b_1);
            a.setright(b_2);
            a.Text = cards[0].ToString();

            b_1.setdata(cards[1]);
            b_1.setleft(c_1);
            b_1.setright(c_2);
            b_1.Text = cards[1].ToString();

            b_2.setdata(cards[2]);
            b_2.setleft(c_2);
            b_2.setright(c_3);
            b_2.Text = cards[2].ToString();

            c_1.setdata(cards[3]);
            c_1.setleft(d_1);
            c_1.setright(d_2);
            c_1.Text = cards[3].ToString();

            c_2.setdata(cards[4]);
            c_2.setleft(d_2);
            c_2.setright(d_3);
            c_2.Text = cards[4].ToString();

            c_3.setdata(cards[5]);
            c_3.setleft(d_3);
            c_3.setright(d_4);
            c_3.Text = cards[5].ToString();

            d_1.setdata(cards[6]);
            d_1.setleft(e_1);
            d_1.setright(e_2);
            d_1.Text = cards[6].ToString();

            d_2.setdata(cards[7]);
            d_2.setleft(e_2);
            d_2.setright(e_3);
            d_2.Text = cards[7].ToString();

            d_3.setdata(cards[8]);
            d_3.setleft(e_3);
            d_3.setright(e_4);
            d_3.Text = cards[8].ToString();

            d_4.setdata(cards[9]);
            d_4.setleft(e_4);
            d_4.setright(e_5);
            d_4.Text = cards[9].ToString();

            e_1.setdata(cards[10]);
            e_1.setleft(f_1);
            e_1.setright(f_2);
            e_1.Text = cards[10].ToString();

            e_2.setdata(cards[11]);
            e_2.setleft(f_2);
            e_2.setright(f_3);
            e_2.Text = cards[11].ToString();

            e_3.setdata(cards[12]);
            e_3.setleft(f_3);
            e_3.setright(f_4);
            e_3.Text = cards[12].ToString();

            e_4.setdata(cards[13]);
            e_4.setleft(f_4);
            e_4.setright(f_5);
            e_4.Text = cards[13].ToString();

            e_5.setdata(cards[14]);
            e_5.setleft(f_5);
            e_5.setright(f_6);
            e_5.Text = cards[14].ToString();

            f_1.setdata(cards[15]);
            f_1.setleft(g_1);
            f_1.setright(g_2);
            f_1.Text = cards[15].ToString();

            f_2.setdata(cards[16]);
            f_2.setleft(g_2);
            f_2.setright(g_3);
            f_2.Text = cards[16].ToString();

            f_3.setdata(cards[17]);
            f_3.setleft(g_3);
            f_3.setright(g_4);
            f_3.Text = cards[17].ToString();

            f_4.setdata(cards[18]);
            f_4.setleft(g_4);
            f_4.setright(g_5);
            f_4.Text = cards[18].ToString();

            f_5.setdata(cards[19]);
            f_5.setleft(g_5);
            f_5.setright(g_6);
            f_5.Text = cards[19].ToString();

            f_6.setdata(cards[20]);
            f_6.setleft(g_6);
            f_6.setright(g_7);
            f_6.Text = cards[20].ToString();

            g_1.setdata(cards[21]);
            g_1.Text= cards[21].ToString();
            g_2.setdata(cards[22]);
            g_2.Text= cards[22].ToString();
            g_3.setdata(cards[23]);
            g_3.Text= cards[23].ToString();
            g_4.setdata(cards[24]);
            g_4.Text= cards[24].ToString();
            g_5.setdata(cards[25]);
            g_5.Text= cards[25].ToString();
            g_6.setdata(cards[26]);
            g_6.Text= cards[26].ToString();
            g_7.setdata(cards[27]);
            g_7.Text= cards[27].ToString();

            S_1.setdata(cards[28]);
            S_1.Text= cards[28].ToString();
            S_2.setdata(cards[29]);
            S_2.Text= cards[29].ToString();
            S_3.setdata(cards[30]);
            S_3.Text= cards[30].ToString();
            S_4.setdata(cards[31]);
            S_4.Text= cards[31].ToString();
            S_5.setdata(cards[32]);
            S_5.Text= cards[32].ToString();
            S_6.setdata(cards[33]);
            S_6.Text = cards[33].ToString();
            S_7.setdata(cards[34]);
            S_7.Text = cards[34].ToString();
            S_8.setdata(cards[35]);
            S_8.Text = cards[35].ToString();
            S_9.setdata(cards[36]);
            S_9.Text = cards[36].ToString();
            S_10.setdata(cards[37]);
            S_10.Text = cards[37].ToString();
            S_11.setdata(cards[38]);
            S_11.Text = cards[38].ToString();
            S_12.setdata(cards[39]);
            S_12.Text = cards[39].ToString();
            S_13.setdata(cards[40]);
            S_13.Text = cards[40].ToString();
            S_14.setdata(cards[41]);
            S_14.Text = cards[41].ToString();
            S_15.setdata(cards[42]);
            S_15.Text = cards[42].ToString();
            S_16.setdata(cards[43]);
            S_16.Text = cards[43].ToString();
            S_17.setdata(cards[44]);
            S_17.Text = cards[44].ToString();
            S_18.setdata(cards[45]);
            S_18.Text = cards[45].ToString();
            S_19.setdata(cards[46]);
            S_19.Text = cards[46].ToString();
            S_20.setdata(cards[47]);
            S_20.Text = cards[47].ToString();
            S_21.setdata(cards[48]);
            S_21.Text = cards[48].ToString();
            S_22.setdata(cards[49]);
            S_22.Text = cards[49].ToString();
            S_23.setdata(cards[50]);
            S_23.Text = cards[50].ToString();
            S_24.setdata(cards[51]);
            S_24.Text = cards[51].ToString();
        }  

        private void a_Click(object sender, EventArgs e) {
            if (a.getLeft() == null && a.getright() == null) { //밑에 받치는 노드가 없다면
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void b_1_Click(object sender, EventArgs e) {
            if (b_1.getLeft() == null && b_1.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void b_2_Click(object sender, EventArgs e) {
            if (b_2.getLeft() == null && b_2.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void c_1_Click(object sender, EventArgs e) {
            if (c_1.getLeft() == null && c_1.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void c_2_Click(object sender, EventArgs e) {
            if (c_2.getLeft() == null && c_2.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void c_3_Click(object sender, EventArgs e) {
            if (c_3.getLeft() == null && c_3.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void d_1_Click(object sender, EventArgs e) {
            if (d_1.getLeft() == null && d_1.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void d_2_Click(object sender, EventArgs e) {
            if (d_2.getLeft() == null && d_2.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void d_3_Click(object sender, EventArgs e) {
            if (d_3.getLeft() == null && d_3.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void d_4_Click(object sender, EventArgs e) {
            if (d_4.getLeft() == null && d_4.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void e_1_Click(object sender, EventArgs e) {
            if (e_1.getLeft() == null && e_1.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void e_2_Click(object sender, EventArgs e) {
            if (e_2.getLeft() == null && e_2.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void e_3_Click(object sender, EventArgs e) {
            if (e_3.getLeft() == null && e_3.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void e_4_Click(object sender, EventArgs e) {
            if (e_4.getLeft() == null && e_4.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void e_5_Click(object sender, EventArgs e) {
            if (e_5.getLeft() == null && e_5.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void f_1_Click(object sender, EventArgs e) {
            if (f_1.getLeft() == null && f_1.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void f_2_Click(object sender, EventArgs e) {
            if (f_2.getLeft() == null && f_2.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void f_3_Click(object sender, EventArgs e) {
            if (f_3.getLeft() == null && f_3.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void f_4_Click(object sender, EventArgs e) {
            if (f_4.getLeft() == null && f_4.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void f_5_Click(object sender, EventArgs e) {
            if (f_5.getLeft() == null && f_5.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void f_6_Click(object sender, EventArgs e) {
            if (f_6.getLeft() == null && f_6.getright() == null) {
                CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
            }
        }

        private void g_1_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void g_2_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void g_3_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void g_4_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void g_5_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void g_6_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void g_7_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_1_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_2_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_3_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_4_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_5_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_6_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_7_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_8_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_9_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_10_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_11_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_12_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_13_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_14_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_15_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_16_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_17_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_18_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_19_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_20_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_21_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_22_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_23_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
        }

        private void S_24_Click(object sender, EventArgs e) {
            CustomBtn clickBtn = sender as CustomBtn; //해당 버튼 제거
    }

    public class CustomBtn : Button {

        private CustomBtn left;
        private CustomBtn right;
        private int data;
        public CustomBtn() {
            left=null;
            right=null;
            data = 0;
        }
        public void setleft(CustomBtn left) {
            this.left = left;
        }
        public void setright(CustomBtn right) {
            this.right = right;
        }
        public void setdata(int data) {
            this.data = data;
        }
        public CustomBtn getLeft() {
            return left;
        }
        public CustomBtn getright() {
            return right;
        }
        public int getData() {
            return data;
        }

        public void resetLeft() {
            this.left=null;
        }
        public void resetRight() {
            this.right=null;
        }
    }
}