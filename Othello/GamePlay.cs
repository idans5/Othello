using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{

    // $G$ CSS-016 (-3) Bad class name - The name of classes derived from Form should start with Form.
    public partial class GamePlayForm : Form
    {
        private const short k_PlayerVsPlayer = 1;
        private const short k_PlayerVsPC = 2;
        private short m_BoardSize = 0;
        private short m_playerChoiseGameTypeShort = 0;
        private string m_playerTurn;
        // $G$ DSN-999 (-3) This kind of field should be readonly.
        private Image m_RedCoin = Resource.CoinRed;
        private Image m_YellowCoin = Resource.CoinYellow;
        private GameProgress m_GameProgress = null;
        private Board m_OthelloBoard = null;
        private Button[,] m_ButtonMatrix = null;
        private Player m_PrimaryPlayer = null;
        private Player m_SecondaryPlayer = null;
        private Directions m_Directions = null;

        public GamePlayForm(short i_BoardSize, bool i_GameType)
        {
            m_PrimaryPlayer = new Player("Red");
            m_PrimaryPlayer.PlayerCoin = 'X';
            m_SecondaryPlayer = new Player("Yellow");
            m_SecondaryPlayer.PlayerCoin = 'O';
            m_BoardSize = i_BoardSize;
            m_GameProgress = new GameProgress();
            m_Directions = new Directions();
            
            if (i_GameType)
            {
                m_playerChoiseGameTypeShort = k_PlayerVsPlayer;
            }
            else
            {
                m_playerChoiseGameTypeShort = k_PlayerVsPC;
            }

            InitializeComponent();
        }

        // $G$ CSS-999 (-3) instead of using strings in a if statement use constants 
        private void changeCoins(Button i_Sender)
        {
            if (m_playerTurn == "Red")
            {
                m_GameProgress.ChangingCoins(ref m_OthelloBoard, i_Sender.Name, m_PrimaryPlayer, m_Directions);
                clearBoardButton();
                updateVisualBoard();
                Refresh();
                changePlayer(m_PrimaryPlayer);
            }
            else
            {
                m_GameProgress.ChangingCoins(ref m_OthelloBoard, i_Sender.Name, m_SecondaryPlayer, m_Directions);
                updateVisualBoard();
                Refresh();
                changePlayer(m_SecondaryPlayer);
            }
        }

        private void gameplayLoad(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            m_OthelloBoard = new Board(m_BoardSize);
            m_playerTurn = "Red";
            m_ButtonMatrix = createBoard(m_OthelloBoard, m_BoardSize);
            playerMove(m_playerTurn);
        }

        private void newGame()
        {            
            m_PrimaryPlayer.PlayerScore = 0;
            m_SecondaryPlayer.PlayerScore = 0;
            m_OthelloBoard = new Board(m_BoardSize);  
            m_playerTurn = "Red";
            clearBoardButton();
            updateVisualBoard();
            playerMove(m_playerTurn);
        }

        // $G$ CSS-999 (-3) instead of using strings in a if statement use constants 
        private void changePlayer(Player i_Player)
        {
            string checkPlayer = i_Player.PlayerName;
            if (checkPlayer == "Red")
            {
                m_playerTurn = "Yellow";
            }
            else
            {
                m_playerTurn = "Red";
            }

            playerMove(m_playerTurn);
        }

        // $G$ DSN-002 (-20) No UI seperation! This class merge the Logic board with the Visual board (UserControl) of the game...
        private void playerMove(string i_PlayerTurn)
        {
            if (m_playerTurn == "Red")
            {
                if (m_GameProgress.ExistMoveForPlayer(m_PrimaryPlayer, ref m_OthelloBoard))
                {
                    Text = "Otello - Red's Turn";
                    List<string> m_PossibleMoveList = m_GameProgress.ValidPlayList(m_PrimaryPlayer, ref m_OthelloBoard);
                    clearBoardButton();
                    updateVisualBoard();
                    changePossibleMoveToGreen(m_PossibleMoveList, ref m_ButtonMatrix);
                    Refresh();
                }
                else
                {
                    if (m_GameProgress.ExistMoveForPlayer(m_SecondaryPlayer, ref m_OthelloBoard))
                    {
                        changePlayer(m_PrimaryPlayer);
                    }
                    else
                    {
                        endGame();
                    }
                }
            }
            else
            {
                if (m_GameProgress.ExistMoveForPlayer(m_SecondaryPlayer, ref m_OthelloBoard))
                {
                    if (m_playerChoiseGameTypeShort == k_PlayerVsPC)
                    {
                        Text = "Otello - PC Turn";                        
                        m_GameProgress.ComputerMove(m_SecondaryPlayer, ref m_OthelloBoard, m_Directions);
                        List<string> m_PossibleMoveList = m_GameProgress.ValidPlayList(m_PrimaryPlayer, ref m_OthelloBoard);
                        clearBoardButton();
                        updateVisualBoard();
                        changePlayer(m_SecondaryPlayer);
                        Refresh();
                    }
                    else
                    {
                        Text = "Otello - Yellow's Turn";
                        List<string> m_PossibleMoveList = m_GameProgress.ValidPlayList(m_SecondaryPlayer, ref m_OthelloBoard);
                        clearBoardButton();
                        updateVisualBoard();
                        changePossibleMoveToGreen(m_PossibleMoveList, ref m_ButtonMatrix);
                    }
                }
                else
                {
                    if (m_GameProgress.ExistMoveForPlayer(m_PrimaryPlayer, ref m_OthelloBoard))
                    {
                        changePlayer(m_SecondaryPlayer);
                    }
                    else
                    {
                        endGame();
                    }
                }
            }
        }

        private void endGame()
        {
            m_GameProgress.CalculateScore(ref m_PrimaryPlayer, ref m_SecondaryPlayer, ref m_OthelloBoard);
            string theWinner = m_GameProgress.TheWinner(m_PrimaryPlayer, m_SecondaryPlayer);

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            StringBuilder endGameString = new StringBuilder();
            if (m_PrimaryPlayer.PlayerScore != m_SecondaryPlayer.PlayerScore)
            {
                if (theWinner == "Red")
                {
                    m_PrimaryPlayer.QuantityOfWins++;
                }
                else
                {
                    m_SecondaryPlayer.QuantityOfWins++;
                }

                endGameString.AppendFormat(
@"=========== GAME OVER ===========
{0} Won!!({1}/{2}) ({3}/{4})
Would you like another round?",
    theWinner,
    m_PrimaryPlayer.PlayerScore,
    m_SecondaryPlayer.PlayerScore,
    m_PrimaryPlayer.QuantityOfWins,
    m_SecondaryPlayer.QuantityOfWins);
            }
            else
            {
                endGameString.AppendFormat(
@"=========== GAME OVER ===========
Tie !!({0}/{1}) ({2}/{3})
Would you like another round?",
m_PrimaryPlayer.PlayerScore,
m_SecondaryPlayer.PlayerScore,
m_PrimaryPlayer.QuantityOfWins,
m_SecondaryPlayer.QuantityOfWins);
            }

            result = MessageBox.Show(endGameString.ToString(), "Othello", buttons);
            if (result == DialogResult.Yes)
            {
                newGame();
            }
            else
            {
                Dispose();
            }
        }

        private void clearBoardButton()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_ButtonMatrix[i, j].BackColor = Color.Gray;
                    m_ButtonMatrix[i, j].BackgroundImage = null;
                    m_ButtonMatrix[i, j].Enabled = false;
                }
            }
        }     

        private void updateVisualBoard()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_OthelloBoard.m_OthelloBoard[i, j] == 'X')
                    {
                        m_ButtonMatrix[i, j].BackgroundImage = m_RedCoin;
                        m_ButtonMatrix[i, j].Enabled = false;
                        m_ButtonMatrix[i, j].BackColor = Color.Gray;
                    }
                    else if (m_OthelloBoard.m_OthelloBoard[i, j] == 'O')
                    {
                        m_ButtonMatrix[i, j].BackgroundImage = m_YellowCoin;
                        m_ButtonMatrix[i, j].Enabled = false;
                        m_ButtonMatrix[i, j].BackColor = Color.Gray;
                    }
                }
            }
        }

        private void changePossibleMoveToGreen(List<string> i_PossibleMoveList, ref Button[,] io_ButtonMatrix)
        {
            for (int k = 0; k < i_PossibleMoveList.Count; k++)
            {
                m_GameProgress.AnalyzeString(i_PossibleMoveList[k], out int row, out int column);
                io_ButtonMatrix[row, column].Enabled = true;
                io_ButtonMatrix[row, column].BackColor = Color.Green;
            }
        }

        private Button[,] createBoard(Board i_Board, short i_BoardSize)
        {
            Button[,] buttonMatrix = new Button[i_BoardSize, i_BoardSize];

            for (int i = 0; i < i_BoardSize; i++)
            {
                for (int j = 0; j < i_BoardSize; j++)
                {
                    buttonMatrix[i, j] = new Button();

                    if (i_Board.m_OthelloBoard[i, j] == 'X')
                    {
                        buttonMatrix[i, j].BackgroundImage = m_RedCoin;
                    }
                    else if (i_Board.m_OthelloBoard[i, j] == 'O')
                    {
                        buttonMatrix[i, j].BackgroundImage = m_YellowCoin;
                    }

                    StringBuilder current = new StringBuilder();
                    current.AppendFormat("{0},{1}", i, j);
                    buttonMatrix[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttonMatrix[i, j].Name = current.ToString();
                    buttonMatrix[i, j].Size = new Size(60, 60);
                    buttonMatrix[i, j].BackColor = Color.Gray;
                    buttonMatrix[i, j].Location = new Point((60 * i) + 20, (60 * j) + 20);
                    Controls.Add(buttonMatrix[i, j]);
                    buttonMatrix[i, j].Click += new EventHandler(button_Click);
                }
            }

            return buttonMatrix;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            changeCoins(btn);
        }
    }
}