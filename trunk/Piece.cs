using System;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a piece in checkers game
    /// </summary>
    class Piece
    {
        #region Properties

        /// <summary>
        /// Gets the player how owns the current piece [read-only]
        /// </summary>
        public Player OwnerPlayer { get; private set; }

        /// <summary>
        /// Indicates whenever the current piece is queen
        /// </summary>
        public bool Queen { get; set; }

        #endregion


        /// <summary>
        /// Creates a new piece
        /// </summary>
        /// <param name="owner">The player who owns this piece</param>
        public Piece(Player owner)
        {
            this.OwnerPlayer = owner;
            this.Queen = false;
        }
    }
}
