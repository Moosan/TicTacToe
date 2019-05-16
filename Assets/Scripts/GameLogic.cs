namespace TicGame
{
    public class GameLogic
    {
        private Mark[][] GameBoard;

        private GameState GameState;

        public GameLogic(Mark first)
        {
            BoardReset();
            GameState = new GameState(first);
        }

        private void BoardReset()
        {
            GameBoard = new Mark[3][];
            for (int i = 0; i < 3; i++)
            {
                GameBoard[i] = new Mark[3];
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i][j] = Mark.None;
                }
            }
        }

        private bool IsEmpty(int x,int y)
        {
            try
            {
                return GameBoard[x][y] == Mark.None;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        private bool IsEnd()
        {
            return GameState.IsEnd;
        }
        public TurnResult Action(int x, int y, Mark mark)
        {
            if (!IsEmpty(x, y)|| IsEnd()) return new TurnResult(false, GameState);
            Do(x, y, mark);
            return new TurnResult(true,GameState);
        }

        private void Do(int x,int y,Mark mark)
        {
            GameBoard[x][y] = mark;
            StateUpdate(mark);
        }

        private void StateUpdate(Mark mark)
        {
            GameState.Turn = mark;
            if (IsAlign(mark))
            {
                GameState.Winner = mark;
                GameState.IsEnd = true;
            }
            if (IsFull())
            {
                GameState.IsFull = true;
                GameState.IsEnd = true;
            }
        }

        private bool IsAlign(Mark mark)
        {
            for (int i = 0; i < 3; i++)
            {
                bool isAlign = true;
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard[i][j] != mark)
                    {
                        isAlign = false;
                        break;
                    }
                }
                if (isAlign)
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                bool isAlign = true;
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard[j][i] != mark)
                    {
                        isAlign = false;
                        break;
                    }
                }
                if (isAlign)
                {
                    return true;
                }
            }
            if(GameBoard[0][0] == mark && GameBoard[1][1] == mark && GameBoard[2][2] == mark)
            {
                return true;
            }
            if (GameBoard[2][0] == mark && GameBoard[1][1] == mark && GameBoard[0][2] == mark)
            {
                return true;
            }
            return false;
        }

        private bool IsFull()
        {
            for(int i = 0;i < GameBoard.Length;i++)
            {
                for(int j = 0; j < GameBoard[i].Length; j++)
                {
                    if (GameBoard[i][j] == Mark.None) return false;
                }
            }
            return true;
        }
    }
}