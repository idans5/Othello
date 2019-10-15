namespace Othello
{
    public class Board
    {
        public char[,] m_OthelloBoard;
        private short m_OthelloBoardSize;

        public Board(short i_OthelloBoardSize)
        {
            m_OthelloBoardSize = i_OthelloBoardSize;
            m_OthelloBoard = new char[m_OthelloBoardSize, m_OthelloBoardSize];
            setStartingBoard();
        }

        public short BoardSize
        {
            get
            {
                return m_OthelloBoardSize;
            }

            set
            {
                m_OthelloBoardSize = value;
            }
        }

        private void setStartingBoard() // Reset Othello board
        {
            for (int i = 0; i < m_OthelloBoardSize; i++)
            {
                for (int j = 0; j < m_OthelloBoardSize; j++)
                {
                    m_OthelloBoard[i, j] = ' ';
                }
            }

            m_OthelloBoard[(m_OthelloBoardSize / 2) - 1, (m_OthelloBoardSize / 2) - 1] = 'X';
            m_OthelloBoard[(m_OthelloBoardSize / 2) - 1, m_OthelloBoardSize / 2] = 'O';
            m_OthelloBoard[m_OthelloBoardSize / 2, (m_OthelloBoardSize / 2) - 1] = 'O';
            m_OthelloBoard[m_OthelloBoardSize / 2, m_OthelloBoardSize / 2] = 'X';
        }
    }
}