using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp
{
    public class OmokRule
    {
        public enum StoneType { None, Black, White };

        const int BoardSize = 19;

        int[,] board = new int[BoardSize, BoardSize];
        public bool BlackTurn { get; private set; } = true;
        public bool IsGameOver { get; private set; } = true;
        public int CurrentTurnCount { get; private set; } = 0;
        public int PreviousStoneX { get; private set; } = -1;
        public int PreviousStoneY { get; private set; } = -1;
        public int CurrentStoneX { get; private set; } = -1;
        public int CurrentStoneY { get; private set; } = -1;

        private Stack<Point> st = new Stack<Point>();

        public void StartGame()
        {
            Array.Clear(board, 0, BoardSize * BoardSize);
            PreviousStoneX = PreviousStoneY = -1;
            CurrentStoneX = CurrentStoneY = -1;
            BlackTurn = true;
            CurrentTurnCount = 1;
            IsGameOver = false;
            st.Clear();
        }

        public void EndGame()
        {
            IsGameOver = true;
            Array.Clear(board, 0, BoardSize * BoardSize);
        }

        public int GetStone(int x, int y)
        {
            return board[x, y];
        }

        public bool IsBlackTurn()
        {
            return ((CurrentTurnCount % 2) == 1);
        }

        public PlaceStoneResult PlaceStone(int x, int y)
        {
            if (BlackTurn)
            {
                board[x, y] = (int)StoneType.Black;
            }
            else
            {
                board[x, y] = (int)StoneType.White;
            }

            if (CheckForThreeThrees(x, y) && BlackTurn)
            {
                board[x, y] = (int)StoneType.None;
                return PlaceStoneResult.SamSam;
            }
            else
            {
                PreviousStoneX = CurrentStoneX;
                PreviousStoneY = CurrentStoneY;

                CurrentStoneX = x;
                CurrentStoneY = y;

                BlackTurn = !BlackTurn;
            }

            ++CurrentTurnCount;
            st.Push(new Point(x, y));
            return PlaceStoneResult.Success;
        }

        public void SwitchTurn()
        {
            BlackTurn = !BlackTurn;
        }

        public void CheckForOmok(int x, int y)
        {
            if (CheckHorizontal(x, y) == 5 || CheckVertical(x, y) == 5 || CheckDiagonal(x, y) == 5 || CheckAntiDiagonal(x, y) == 5)
            {
                IsGameOver = true;
            }
        }

        int CheckHorizontal(int x, int y)
        {
            int count = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (x + i <= 18 && board[x + i, y] == board[x, y])
                    count++;
                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (x - i >= 0 && board[x - i, y] == board[x, y])
                    count++;
                else
                    break;
            }

            return count;
        }

        int CheckVertical(int x, int y)
        {
            int count = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (y + i <= 18 && board[x, y + i] == board[x, y])
                    count++;
                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (y - i >= 0 && board[x, y - i] == board[x, y])
                    count++;
                else
                    break;
            }

            return count;
        }

        int CheckDiagonal(int x, int y)
        {
            int count = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (x + i <= 18 && y - i >= 0 && board[x + i, y - i] == board[x, y])
                    count++;
                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (x - i >= 0 && y + i <= 18 && board[x - i, y + i] == board[x, y])
                    count++;
                else
                    break;
            }

            return count;
        }

        int CheckAntiDiagonal(int x, int y)
        {
            int count = 1;

            for (int i = 1; i <= 5; i++)
            {
                if (x + i <= 18 && y + i <= 18 && board[x + i, y + i] == board[x, y])
                    count++;
                else
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                if (x - i >= 0 && y - i >= 0 && board[x - i, y - i] == board[x, y])
                    count++;
                else
                    break;
            }

            return count;
        }

        bool CheckForThreeThrees(int x, int y)
        {
            int count = 0;

            count += CheckHorizontalThreeThrees(x, y);
            count += CheckVerticalThreeThrees(x, y);
            count += CheckDiagonalThreeThrees(x, y);
            count += CheckAntiDiagonalThreeThrees(x, y);

            return count >= 2;
        }

        int CheckHorizontalThreeThrees(int x, int y)
        {
            int count = 1;
            int i, j;

            for (i = 1; i <= 3; i++)
            {
                if (x + i > 18)
                    break;
                else if (board[x + i, y] == board[x, y])
                    count++;
                else if (board[x + i, y] != (int)StoneType.None)
                    break;
            }

            for (j = 1; j <= 3; j++)
            {
                if (x - j < 0)
                    break;
                else if (board[x - j, y] == board[x, y])
                    count++;
                else if (board[x - j, y] != (int)StoneType.None)
                    break;
            }

            if (count == 3 && x + i < 18 && x - j > 0)
            {
                if ((board[x + i, y] != (int)StoneType.None && board[x + i - 1, y] != (int)StoneType.None) || (board[x - j, y] != (int)StoneType.None && board[x - j + 1, y] != (int)StoneType.None))
                {
                    return 0;
                }
                else
                    return 1;
            }

            return 0;
        }

        int CheckVerticalThreeThrees(int x, int y)
        {
            int count = 1;
            int i, j;

            count = 1;

            for (i = 1; i <= 3; i++)
            {
                if (y + i > 18)
                    break;
                else if (board[x, y + i] == board[x, y])
                    count++;
                else if (board[x, y + i] != (int)StoneType.None)
                    break;
            }

            for (j = 1; j <= 3; j++)
            {
                if (y - j < 0)
                    break;
                else if (board[x, y - j] == board[x, y])
                    count++;
                else if (board[x, y - j] != (int)StoneType.None)
                    break;
            }

            if (count == 3 && y + i < 18 && y - j > 0)
            {
                if ((board[x, y + i] != (int)StoneType.None && board[x, y + i - 1] != (int)StoneType.None) || (board[x, y - j] != (int)StoneType.None && board[x, y - j + 1] != (int)StoneType.None))
                {
                    return 0;
                }
                else
                    return 1;
            }

            return 0;
        }

        int CheckDiagonalThreeThrees(int x, int y)
        {
            int count = 1;
            int i, j;

            count = 1;

            for (i = 1; i <= 3; i++)
            {
                if (x + i > 18 || y - i < 0)
                    break;
                else if (board[x + i, y - i] == board[x, y])
                    count++;
                else if (board[x + i, y - i] != (int)StoneType.None)
                    break;
            }

            for (j = 1; j <= 3; j++)
            {
                if (x - j < 0 || y + j > 18)
                    break;
                else if (board[x - j, y + j] == board[x, y])
                    count++;
                else if (board[x - j, y + j] != (int)StoneType.None)
                    break;
            }

            if (count == 3 && x + i < 18 && y - i > 0 && x - j > 0 && y + j < 18)
            {
                if ((board[x + i, y - i] != (int)StoneType.None && board[x + i - 1, y - i + 1] != (int)StoneType.None) || (board[x - j, y + j] != (int)StoneType.None && board[x - j + 1, y + j - 1] != (int)StoneType.None))
                {
                    return 0;
                }
                else
                    return 1;
            }

            return 0;
        }

        int CheckAntiDiagonalThreeThrees(int x, int y)
        {
            int count = 1;
            int i, j;

            count = 1;

            for (i = 1; i <= 3; i++)
            {
                if (x + i > 18 || y + i > 18)
                    break;
                else if (board[x + i, y + i] == board[x, y])
                    count++;
                else if (board[x + i, y + i] != (int)StoneType.None)
                    break;
            }

            for (j = 1; j <= 3; j++)
            {
                if (x - j < 0 || y - j < 0)
                    break;
                else if (board[x - j, y - j] == board[x, y])
                    count++;
                else if (board[x - j, y - j] != (int)StoneType.None)
                    break;
            }

            if (count == 3 && x + i < 18 && y + i < 18 && x - j > 0 && y - j > 0)
            {
                if ((board[x + i, y + i] != (int)StoneType.None && board[x + i - 1, y + i - 1] != (int)StoneType.None) || (board[x - j, y - j] != (int)StoneType.None && board[x - j + 1, y - j + 1] != (int)StoneType.None))
                {
                    return 0;
                }
                else
                    return 1;
            }

            return 0;
        }
    }

    public enum PlaceStoneResult
    {
        Success = 0,
        SamSam = 1,
    }
}
