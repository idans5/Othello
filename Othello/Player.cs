namespace Othello
{
    // $G$ DSN-999 (-3) Better use a struct here
    public class Player
    {
        private int m_PlayerScore;
        private char m_PlayerCoin;
        private string m_PlayerName;
        private short m_QuantityOfWins;

        public Player(string i_PlayerName)
        {
            m_PlayerName = i_PlayerName;
            m_PlayerScore = 0;
        }

        public short QuantityOfWins
        {
            get
            {
                return m_QuantityOfWins;
            }

            set
            {
                m_QuantityOfWins = value;
            }
        }

        public int PlayerScore
        {
            get
            {
                return m_PlayerScore;
            }

            set
            {
                m_PlayerScore = value;
            }
        }

        public char PlayerCoin
        {
            get
            {
                return m_PlayerCoin;
            }

            set
            {
                m_PlayerCoin = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }

            set
            {
                m_PlayerName = value;
            }
        }
    }
}