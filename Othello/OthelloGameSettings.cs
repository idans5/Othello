using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{

    // $G$ CSS-016 (-3) Bad class name - The name of classes derived from Form should start with Form.
    public partial class OthelloGameSettingsForm : Form
    {
        private const short k_MaximumBoardSize = 12;
        private const short k_MinimumBoardSize = 6;
        private short m_BoardSize;

        public OthelloGameSettingsForm()
        {
            m_BoardSize = k_MinimumBoardSize;
            InitializeComponent();
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            if (m_BoardSize == k_MaximumBoardSize)
            {
                m_BoardSize = k_MinimumBoardSize;
            }
            else
            {
                m_BoardSize += 2;
            }

            StringBuilder stringBoardSize = new StringBuilder();
            stringBoardSize.AppendFormat("Board Size: {0}x{0} (click to increase)", m_BoardSize);

            buttonBoardSize.Text = stringBoardSize.ToString();
        }

        private void buttonPlayVsPC_Click(object sender, EventArgs e)
        {            
            goToGamePlay(false);           
        }

        private void buttonPlayVsPlayer_Click(object sender, EventArgs e)
        {
            goToGamePlay(true);
        }

        private void goToGamePlay(bool i_GameType)
        {
            Dispose();

            GamePlayForm gamePlayForm = new GamePlayForm(m_BoardSize, i_GameType);
            gamePlayForm.Size = new Size(m_BoardSize  * 60, (m_BoardSize * 60) + 20);
            gamePlayForm.MinimumSize = new Size((m_BoardSize + 1) * 60, ((m_BoardSize + 1) * 60) + 20);
            gamePlayForm.MaximumSize = new Size((m_BoardSize + 1) * 60, ((m_BoardSize + 1) * 60) + 20);
            gamePlayForm.ShowDialog();
        }
    }
}