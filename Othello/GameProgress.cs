using System;
using System.Collections.Generic;

namespace Othello
{
    public class GameProgress
    {
        public bool ExistMoveForPlayer(Player i_Player, ref Board io_OthelloBoard)
        {
            List<string> possibleMoveList = new List<string>();
            bool checkExistMoveForPlayer = false;
            possibleMoveList = ValidPlayList(i_Player, ref io_OthelloBoard);

            if (possibleMoveList.Count != 0)
            {
                checkExistMoveForPlayer = true;
            }

            return checkExistMoveForPlayer;
        }

        public string TheWinner(Player i_PrimaryPlayer, Player i_SecondaryPlayer)
        {
            string winnerName;

            if (i_PrimaryPlayer.PlayerScore > i_SecondaryPlayer.PlayerScore)
            {
                winnerName = i_PrimaryPlayer.PlayerName;
            }
            else
            {
                winnerName = i_SecondaryPlayer.PlayerName;
            }

            return winnerName;
        }

        public void AnalyzeString(string i_PossibleMove, out int o_Row, out int o_Column)
        {
            int index = 0;
            o_Row = 0;
            o_Column = 0;

            while (i_PossibleMove[index] != ',')
            {
                o_Row = (o_Row * 10) + (int)(i_PossibleMove[index] - 48);
                index++;
            }

            index++;

            while (index < i_PossibleMove.Length)
            {
                o_Column = (o_Column * 10) + (int)(i_PossibleMove[index] - 48);
                index++;
            }
        }

        public void ChangingCoins(ref Board io_OthelloBoard, string i_PossibleMove, Player i_Player, Directions i_Directions)
        {
            AnalyzeString(i_PossibleMove, out int row, out int column);
            int scanRow;
            int scanColumn;

            io_OthelloBoard.m_OthelloBoard[row, column] = i_Player.PlayerCoin;

            for (int i = 0; i < 8; i++)
            {
                if ((row + i_Directions.m_DirectionList[i].X >= 0) && (column + i_Directions.m_DirectionList[i].Y >= 0) && ((row + i_Directions.m_DirectionList[i].X) < io_OthelloBoard.BoardSize) && ((column + i_Directions.m_DirectionList[i].Y) < io_OthelloBoard.BoardSize))
                {
                    if (io_OthelloBoard.m_OthelloBoard[(row + i_Directions.m_DirectionList[i].X), (column + i_Directions.m_DirectionList[i].Y)] != ' ')
                    {
                        scanRow = row;
                        scanColumn = column;

                        scanRow = scanRow + i_Directions.m_DirectionList[i].X;
                        scanColumn = scanColumn + i_Directions.m_DirectionList[i].Y;

                        while (((scanRow >= 0) && (scanRow < io_OthelloBoard.BoardSize) && (scanColumn >= 0)) && (scanColumn < io_OthelloBoard.BoardSize) && (io_OthelloBoard.m_OthelloBoard[scanRow, scanColumn] != ' ') && (io_OthelloBoard.m_OthelloBoard[scanRow, scanColumn] != i_Player.PlayerCoin))
                        {
                            scanRow = scanRow + i_Directions.m_DirectionList[i].X;
                            scanColumn = scanColumn + i_Directions.m_DirectionList[i].Y;
                            if (isInBoard(ref io_OthelloBoard, scanRow, scanColumn) && (io_OthelloBoard.m_OthelloBoard[scanRow, scanColumn] == i_Player.PlayerCoin))
                            {
                                scanRow = scanRow - i_Directions.m_DirectionList[i].X;
                                scanColumn = scanColumn - i_Directions.m_DirectionList[i].Y;

                                while (io_OthelloBoard.m_OthelloBoard[scanRow, scanColumn] != i_Player.PlayerCoin)
                                {
                                    io_OthelloBoard.m_OthelloBoard[scanRow, scanColumn] = i_Player.PlayerCoin;
                                    scanRow = scanRow - i_Directions.m_DirectionList[i].X;
                                    scanColumn = scanColumn - i_Directions.m_DirectionList[i].Y;
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<string> ValidPlayList(Player i_Player, ref Board io_OthelloBoard)
        {
            List<string> possibleMoveList = new List<string>();

            for (int i = 0; i < io_OthelloBoard.BoardSize; i++)
            {
                for (int j = 0; j < io_OthelloBoard.BoardSize; j++)
                {
                    if ((io_OthelloBoard.m_OthelloBoard[i, j] != ' ') && (io_OthelloBoard.m_OthelloBoard[i, j] != i_Player.PlayerCoin))
                    {
                        isValidMove(i, j, ref io_OthelloBoard, i_Player, ref possibleMoveList);
                    }
                }
            }

            return possibleMoveList;
        }

        public void CalculateScore(ref Player io_PrimaryPlayer, ref Player io_SecondaryPlayer, ref Board io_OthelloBoard)
        {
            for (int i = 0; i < io_OthelloBoard.BoardSize; i++)
            {
                for (int j = 0; j < io_OthelloBoard.BoardSize; j++)
                {
                    if (io_OthelloBoard.m_OthelloBoard[i, j] == 'X')
                    {
                        io_PrimaryPlayer.PlayerScore = io_PrimaryPlayer.PlayerScore + 1;
                    }
                    else
                    {
                        if (io_OthelloBoard.m_OthelloBoard[i, j] == 'O')
                        {
                            io_SecondaryPlayer.PlayerScore = io_SecondaryPlayer.PlayerScore + 1;
                        }
                    }
                }
            }
        }

        public void ComputerMove(Player i_Player, ref Board io_OthelloBoard, Directions i_Directions)
        {
            List<string> possibleMoveList = new List<string>();
            possibleMoveList = ValidPlayList(i_Player, ref io_OthelloBoard);

            Random random = new Random();
            int randomMove = random.Next(0, possibleMoveList.Count);

            ChangingCoins(ref io_OthelloBoard, possibleMoveList[randomMove], i_Player, i_Directions);

            System.Threading.Thread.Sleep(1500);
        }

        private bool isInBoard(ref Board io_OthelloBoard, int i_ScanRow, int i_ScanColumn)
        {
            bool checkIsInBoard = false;

            if ((i_ScanRow >= 0) && (i_ScanRow < io_OthelloBoard.BoardSize) && (i_ScanColumn >= 0) && (i_ScanColumn < io_OthelloBoard.BoardSize))
            {
                checkIsInBoard = true;
            }

            return checkIsInBoard;
        }

        private void isValidMove(int i_Row, int i_Column, ref Board io_OthelloBoard, Player i_Player, ref List<string> io_PossibleMoveList)
        {
            int scanRow;
            int scanColumn;
            string addStringToList = null;

            Directions DL = new Directions();

            for (int i = 0; i < 8; i++)
            {
                if ((i_Row + DL.m_DirectionList[i].X >= 0) && (i_Column + DL.m_DirectionList[i].Y >= 0) && ((i_Row + DL.m_DirectionList[i].X) < io_OthelloBoard.BoardSize) && ((i_Column + DL.m_DirectionList[i].Y) < io_OthelloBoard.BoardSize))
                {
                    if (io_OthelloBoard.m_OthelloBoard[(i_Row + DL.m_DirectionList[i].X), (i_Column + DL.m_DirectionList[i].Y)] == ' ')
                    {
                        scanRow = i_Row;
                        scanColumn = i_Column;

                        while (((scanRow >= 0) && (scanRow < io_OthelloBoard.BoardSize) && (scanColumn >= 0)) && (scanColumn < io_OthelloBoard.BoardSize) && (io_OthelloBoard.m_OthelloBoard[scanRow, scanColumn] != ' '))
                        {
                            if (io_OthelloBoard.m_OthelloBoard[scanRow, scanColumn] == i_Player.PlayerCoin)
                            {
                                addStringToList = string.Format("{0},{1}", (char)(i_Row + DL.m_DirectionList[i].X + 48), (char)(i_Column + DL.m_DirectionList[i].Y + 48));
                                io_PossibleMoveList.Add(addStringToList);
                            }

                            scanRow = scanRow - DL.m_DirectionList[i].X;
                            scanColumn = scanColumn - DL.m_DirectionList[i].Y;
                        }
                    }
                }
            }
        }
    }
}