namespace TicGame
{
    public struct TurnResult
    {
        public bool IsSuccess;
        public Mark NextTurn;
        public Mark Winner;
        public bool IsFull;
        public TurnResult(bool isSuccess,GameState gameState)
        {
            IsSuccess = isSuccess;
            NextTurn = gameState.NextTurn;
            Winner = gameState.Winner;
            IsFull = gameState.IsFull;
        }
    }
}