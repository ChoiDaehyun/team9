using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Main_Form
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            fps = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            pointlb = new Label();
            panel1 = new DoubleBufferedPanel();
            panel2 = new Panel();
            label2 = new Label();
            SuspendLayout();
            // 
            // fps
            // 
            fps.Interval = 1;
            fps.Tick += fps_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(600, 7);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "점수 : ";
            // 
            // pointlb
            // 
            pointlb.AutoSize = true;
            pointlb.Location = new Point(640, 7);
            pointlb.Margin = new Padding(2, 0, 2, 0);
            pointlb.Name = "pointlb";
            pointlb.Size = new Size(39, 15);
            pointlb.TabIndex = 1;
            pointlb.Text = "label2";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 560);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(600, 160);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(80, 400);
            panel2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(603, 93);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 4;
            label2.Text = "<- limit";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 561);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pointlb);
            Controls.Add(label1);
            DoubleBuffered = true;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer fps;
        private Label label1;
        private Label pointlb;
        private Panel panel2;
        private Label label2;
        private DoubleBufferedPanel panel1;
    }
}
