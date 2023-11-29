using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region properties
        Panel chessBoar;

        public Panel ChessBoar { get => chessBoar; set => chessBoar = value; }
        public List<Player> PlayerList { get => playerList; set => playerList = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public TextBox PlayerName { get => playerName; set => playerName = value; }
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }

        private List<Player> playerList;

        private int currentPlayer;
        private TextBox playerName;
        private PictureBox playerMark;
        #endregion

        #region construct
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark) 
        {
            this.chessBoar = chessBoard;
            this.PlayerList = new List<Player>()
            {
                new Player("Q9",Image.FromFile(Application.StartupPath +"\\Resources\\characterO.png")),
                new Player("QT",Image.FromFile(Application.StartupPath +"\\Resources\\characterX.png"))
            };
            this.currentPlayer = 0;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            changePlayer();
        }  
        #endregion

        #region methods
        public void DrawChessBoard()
        {
            Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    btn.Click += Btn_Click1;

                    chessBoar.Controls.Add(btn);
                    oldbtn = btn;
                }
                oldbtn.Location = new Point(0, oldbtn.Location.Y + Cons.CHESS_HEIGHT);
                oldbtn.Width = 0;
                oldbtn.Height = 0;
            }
        }

        private void Btn_Click1(object? sender, EventArgs e)
        {
            Button b = sender as Button;

            if (b.BackgroundImage != null)
                return;

            mark(b);

            changePlayer();
            

        }

        public void mark(Button b)
        {
            b.BackgroundImage = playerList[CurrentPlayer].Mark;

            CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
        }

        public void changePlayer()
        {
            PlayerName.Text = playerList[CurrentPlayer].Name;
            PlayerMark.Image = playerList[CurrentPlayer].Mark;
        }

        #endregion
    }
}
