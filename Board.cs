using System;
using System.Collections.Generic;

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
        private List<Player> thePlayers;
        private PositionStatus[,] positionCache;
        private bool cacheOutdated;

        #endregion


        /// <summary>
        /// Creates a new checkers board
        /// </summary>
        /// <param name="players">The player list</param>
        public Board(List<Player> players)
        {
            this.theBoard = new Piece[BOARD_SIZE, BOARD_SIZE];
            this.thePlayers = new List<Player>(players);
            this.positionCache = new PositionStatus[BOARD_SIZE, BOARD_SIZE];
            this.cacheOutdated = false;
            populateBoard();
            generatePositionCache();
        }

        /// <summary>
        /// Populates the board with the pieces
        /// </summary>
        private void populateBoard()
        {
            // "Each player has a dark square on his far left and a light square on his far right."
            // http://www.jimloy.com/checkers/rules2.htm

            // first player
            for (int i = 0; i < 4; i++)
                for (int c = (i % 2); c < 8; c += 2)
                    this.theBoard[i, c] = new Piece(this.thePlayers[0]);

            // second player
            for (int i = 4; i < 8; i++)
                for (int c = (i % 2); c < 8; c += 2)
                    this.theBoard[i, c] = new Piece(this.thePlayers[1]);
        }

        /// <summary>
        /// Generates a fresh position cache
        /// </summary>
        private void generatePositionCache()
        {
            // TODO This method can be FASTER if it only counts differences to the last play
            // eg. update only the changed pieces since the last move
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (this.theBoard[i, j] == null)
                    {
                        PositionStatus p = new PositionStatus();
                        p.IsOccupied = false;
                        this.positionCache[i, j] = new PositionStatus();
                    }
                    else
                    {
                        PositionStatus p = new PositionStatus();
                        p.IsOccupied = true;
                        p.ThePlayer = this.theBoard[i, j].OwnerPlayer;
                        p.IsQueen = this.theBoard[i, j].Queen;
                        this.positionCache[i, j] = p;
                    }
                }
            }
        }

        /// <summary>
        /// Generates a position cache for clients
        /// </summary>
        /// <returns>Position cache of all pieces</returns>
        public PositionStatus[,] getPiecesPosition()
        {
            Object justToLockThread = new Object();

            lock (justToLockThread)
            {
                if (this.cacheOutdated)
                    generatePositionCache();

                return this.positionCache;
            }
        }
    }


    /// <summary>
    /// Indicates the status of current position on the board
    /// </summary>
    public struct PositionStatus
    {
        /// <summary>
        /// Indicates whenever the current board position is ocuppied whith a piece or not
        /// </summary>
        public bool IsOccupied { get; internal set; }

        /// <summary>
        /// Indicates the players who owns the piece of this position (if any)
        /// </summary>
        /// <remarks>
        /// If there's no piece in this position, the player wil return null
        /// </remarks>
        public Player ThePlayer { get; internal set; }

        /// <summary>
        /// Indicates if the current piece is queen (if any)
        /// </summary>
        public bool IsQueen { get; internal set; }
    }


    [Serializable]
    public class CheckersBoardException : Exception
    {
        public CheckersBoardException() { }
        public CheckersBoardException(string message) : base(message) { }
        public CheckersBoardException(string message, Exception inner) : base(message, inner) { }
        protected CheckersBoardException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
