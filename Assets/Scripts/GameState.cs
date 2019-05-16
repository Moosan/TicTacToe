namespace TicGame
{
    public class GameState
    {
        public Mark Winner;
        public Mark Turn;
        public bool IsFull;
        public bool IsEnd;
        public Mark NextTurn { get {
                if (Turn == Mark.None) return Mark.None;
                return Turn == Mark.Maru ? Mark.Batu : Mark.Maru;
            } }
        public GameState(Mark turn)
        {
            Winner = Mark.None;
            Turn = turn;
            IsFull = false;
            IsEnd = false;
        }
    }
}
