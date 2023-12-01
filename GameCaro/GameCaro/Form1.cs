using System.Security.Cryptography.Xml;

namespace GameCaro
{
    public partial class Form1 : Form
    {

        #region properties
        ChessBoardManager boardManager;
        #endregion
        public Form1()
        {
            InitializeComponent();
            boardManager = new ChessBoardManager(pnlChessboard, txtPlayerName, ptrbMark);
            boardManager.PlayerMarked += BoardManager_PlayerMarked;
            boardManager.EndedGame += BoardManager_EndedGame;

            CountDown.Step = Cons.COUNT_DOWN_STEP;
            CountDown.Maximum = Cons.COUNT_DOWN_TIME;
            CountDown.Value = 0;

            tmCountDown.Interval = Cons.COUNT_DOWN_INTERVAL;

            NewGame();
        }

        private void NewGame()
        {
            CountDown.Value = 0;
            tmCountDown.Stop();
            boardManager.DrawChessBoard();
            
        }

        private void Undo()
        {

        }

        private void Quit()
        {
            Application.Exit();
        }

        private void EndGame()
        {
            tmCountDown.Stop();
            pnlChessboard.Enabled = false;
            MessageBox.Show("Ket thuc");
        }

        private void BoardManager_EndedGame(object? sender, EventArgs e)
        {
            EndGame();
        }

        private void BoardManager_PlayerMarked(object? sender, EventArgs e)
        {
            tmCountDown.Start();
            CountDown.Value = 0;
        }

        private void tmCoundDown_Tick(object sender, EventArgs e)
        {
            CountDown.PerformStep();
            if (CountDown.Value == CountDown.Maximum)
            {
                EndGame();
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           if(MessageBox.Show("b co muon dong khong","Thong bao", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
