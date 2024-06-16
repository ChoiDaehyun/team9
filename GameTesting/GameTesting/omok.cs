using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameTesting;

namespace GameTesting
{
    public partial class omok : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        #endregion
        public omok()
        {
            InitializeComponent();

            ChessBoard = new ChessBoardManager(pnlChessBoard, txbPlayerName, pctbMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            prcbCoolDown.Step = Cons.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;

            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            NewGame();
        }

        #region Methods

        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("Good Game!", "Warning");
        }

        void NewGame()
        {
            ChessBoard.DrawChessBoard();
            undoToolStripMenuItem.Enabled = true;
            prcbCoolDown.Value = 0;
            tmCoolDown.Stop();
        }
        void Quit()
        {
            Application.Exit();
        }

        void Undo()
        {
            ChessBoard.Undo();
            prcbCoolDown.Value = 0;
            tmCoolDown.Start();

        }

        void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            prcbCoolDown.Value = 0;
        }

        void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();

            if (prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                EndGame();
            }
        }
                

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmCoolDown.Stop();
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmCoolDown.Stop();
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmCoolDown.Stop();
            Quit();
        }



        #endregion

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            tmCoolDown.Stop();
            if (MessageBox.Show("Are you sure to quit the game?", "Warning", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            tmCoolDown.Start();

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmCoolDown.Stop();
        }
    }
}
