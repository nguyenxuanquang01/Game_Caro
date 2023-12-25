using Microsoft.VisualBasic.Devices;
using System.Net.NetworkInformation;
using System.Security.Cryptography.Xml;

namespace GameCaro
{
    public partial class Form1 : Form
    {

        #region properties
        ChessBoardManager boardManager;
        SocketMangager socket;
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

            socket = new SocketMangager();

            NewGame();
        }

        private void NewGame()
        {
            undoToolStripMenuItem.Enabled = true;
            CountDown.Value = 0;
            tmCountDown.Stop();
            boardManager.DrawChessBoard();

        }

        private void Undo()
        {
            boardManager.Undo();
        }

        private void Quit()
        {
            Application.Exit();
        }

        private void EndGame()
        {
            tmCountDown.Stop();
            pnlChessboard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("Ket thuc");
        }

        private void BoardManager_EndedGame(object? sender, EventArgs e)
        {
            EndGame();
        }

        private void BoardManager_PlayerMarked(object? sender, ButtonClickEvent e)
        {
            tmCountDown.Start();
            CountDown.Value = 0;

            socket.Send(new SocketData((int) SocketCommand.SEND_POINT, "", e.ClickPoint));

            Listen();
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
            if (MessageBox.Show("b co muon dong khong", "Thong bao", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txtbIP.Text;

            if (!socket.ConnectServer())
            {
                socket.CreateServer();
            }
            else
            {
                Listen();
            }
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txtbIP.Text))
            {
                txtbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        void Listen()
        {

            try
            {
                Thread thread = new Thread(() =>
                {
                    SocketData data = (SocketData)socket.Receive();

                    ProcessData(data);
                });
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {

            }
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTITY:
                    MessageBox.Show(data.Message); 
                    break;
                case (int)SocketCommand.UNDO: 
                    break;
                case(int)SocketCommand.NEW_GAME: 
                    break;
                case(int)SocketCommand.SEND_POINT:
                    boardManager.otherPlayerMark(data.Point);
                    break;
                case(int)SocketCommand.QUIT: 
                    break;
                default: 
                    break;
              
            }
            Listen();
        }
    }
}
