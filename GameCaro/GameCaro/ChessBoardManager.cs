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
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private List<Player> playerList;

        private int currentPlayer;
        private TextBox playerName;
        private PictureBox playerMark;

        private List<List<Button>> matrix;

        private event EventHandler playerMarked;
        public event EventHandler PlayerMarked
        {
            add { playerMarked += value; } 
            remove { playerMarked -= value; }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add { endedGame += value; }
            remove { endedGame -= value; }
        }

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
            
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            
        }  
        #endregion

        #region methods
        public void DrawChessBoard()
        {
            chessBoar.Enabled = true;
            chessBoar.Controls.Clear();

            CurrentPlayer = 0;
            changePlayer();

            Matrix = new List<List<Button>>();
            Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };

                    btn.Click += Btn_Click1;

                    Matrix[i].Add(btn);

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
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;

            mark(btn);

            changePlayer();

            if (playerMarked != null)
            {
                playerMarked(this, new EventArgs());
            }

            if (isEndGame(btn))
            {
                endGame();
            }
        }

        private void endGame()
        {
            if (endedGame != null)
            {
                endedGame(this, new EventArgs());
            }
        }

        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn)|| isEndSub(btn);
        }

        private Point getChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            
            Point point = new Point(horizontal, vertical);
            return point;
        }
        private bool isEndHorizontal(Button btn)
        {
            Point point = getChessPoint(btn);

            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                {
                    break;
                }
                
            }

            int countRight = 0;
            for (int i = point.X+1; i <= Cons.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                {
                    break;
                }

            }

            return countLeft + countRight == 5;
        }
        private bool isEndVertical(Button btn)
        {
            Point point = getChessPoint(btn);

            int countAbove = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countAbove++;
                }
                else
                {
                    break;
                }

            }

            int countLow = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countLow++;
                }
                else
                {
                    break;
                }

            }

            return countAbove + countLow == 5;
        }
        private bool isEndPrimary(Button btn)
        {
            Point point = getChessPoint(btn);

            int countPrimaryAbove = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i <0)
                {
                    break;
                }
                if (Matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                {
                    countPrimaryAbove++;
                }
                else
                {
                    break;
                }

            }

            int countPrimaryLow = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.X + i >= Cons.CHESS_BOARD_WIDTH || point.Y + i >= Cons.CHESS_BOARD_HEIGHT)
                {
                    break;
                }
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countPrimaryLow++;
                }
                else
                {
                    break;
                }

            }

            return countPrimaryAbove + countPrimaryLow == 5;
        }
        private bool isEndSub(Button btn)
        {
            Point point = getChessPoint(btn);

            int countSubAbove = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= Cons.CHESS_BOARD_WIDTH || point.Y - i < 0)
                {
                    break;
                }
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countSubAbove++;
                }
                else
                {
                    break;
                }

            }

            int countSubLow = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= Cons.CHESS_BOARD_HEIGHT)
                {
                    break;
                }
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countSubLow++;
                }
                else
                {
                    break;
                }

            }

            return countSubAbove + countSubLow == 5;
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
