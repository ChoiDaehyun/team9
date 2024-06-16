namespace teamproject
{
    partial class Tetris
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer_down = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // timer_down
            // 
            timer_down.Enabled = true;
            timer_down.Interval = 1000;
            timer_down.Tick += timer_down_Tick;
            // 
            // Tetris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 579);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Tetris";
            Text = "Form1";
            FormClosing += fo;
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer_down;
    }
}

