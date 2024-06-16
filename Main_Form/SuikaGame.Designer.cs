namespace team9_wm
{
    partial class SuikaGame
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
            fps.Interval = 16;
            fps.Tick += fps_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(857, 12);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 0;
            label1.Text = "점수 : ";
            // 
            // pointlb
            // 
            pointlb.AutoSize = true;
            pointlb.Location = new Point(914, 12);
            pointlb.Name = "pointlb";
            pointlb.Size = new Size(60, 25);
            pointlb.TabIndex = 1;
            pointlb.Text = "label2";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(856, 932);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(857, 267);
            panel2.Name = "panel2";
            panel2.Size = new Size(113, 665);
            panel2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(861, 155);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 4;
            label2.Text = "<- limit";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(977, 935);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pointlb);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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
