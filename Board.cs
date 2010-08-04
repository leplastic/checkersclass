using System;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a game board for checkers game
    /// </summary>
    class Board
    {
        #region Variables

        private const int BOARD_SIZE = 8;
        private Piece[,] theBoard;
        private GameLog theLog;

        #endregion

        public Board()
        {
            this.theBoard = new Piece[BOARD_SIZE, BOARD_SIZE];
            this.theLog = new GameLog();
        }

    }
}
