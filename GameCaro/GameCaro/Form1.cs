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
            boardManager = new ChessBoardManager(pnlChessboard,txtPlayerName,ptrbMark);
            boardManager.DrawChessBoard();
        }

        
    }
}
