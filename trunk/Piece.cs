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
        internal Player OwnerPlayer { get; private set; }

        /// <summary>
        /// Indicates whenever the current piece is queen
        /// </summary>
        internal bool Queen { get; set; }

        /// <summary>
        /// Indicates the direction of the current piece
        /// </summary>
        internal PieceDirection Direction { get; set; }

        #endregion


        /// <summary>
        /// Creates a new piece
        /// </summary>
        /// <param name="owner">The player who owns this piece</param>
        internal Piece(Player owner)
        {
            this.OwnerPlayer = owner;
            this.Queen = false;
        }
    }


    /// <summary>
    /// Represents the direction of the piece
    /// </summary>
    internal enum PieceDirection
    {
        /// <summary>
        /// The piece goes up (visual representation)
        /// </summary>
        NORTH,

        /// <summary>
        /// The piece goes down (visual representation)
        /// </summary>
        SOUTH,

        /// <summary>
        /// The piece can move in any direction. Intended for Queens.
        /// </summary>
        ANY
    }
}
