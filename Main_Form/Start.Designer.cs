namespace team9_wm
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            button1.Location = new Point(60, 396);
            button1.Name = "button1";
            button1.Size = new Size(309, 155);
            button1.TabIndex = 0;
            button1.Text = "수박게임";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            button2.Location = new Point(427, 396);
            button2.Name = "button2";
            button2.Size = new Size(313, 157);
            button2.TabIndex = 1;
            button2.Text = "테트리스";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            button3.Location = new Point(60, 595);
            button3.Name = "button3";
            button3.Size = new Size(309, 155);
            button3.TabIndex = 2;
            button3.Text = "피라미드";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            button4.Location = new Point(427, 595);
            button4.Name = "button4";
            button4.Size = new Size(313, 155);
            button4.TabIndex = 3;
            button4.Text = "오목";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 40F, FontStyle.Bold);
            label1.Location = new Point(205, 95);
            label1.Name = "label1";
            label1.Size = new Size(400, 72);
            label1.TabIndex = 4;
            label1.Text = "PLAYGROUND";
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 782);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Start";
            Text = "main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
    }
}