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

        #endregion


        /// <summary>
        /// Creates a new checkers board
        /// </summary>
        /// <param name="players">The player list</param>
        public Board(List<Player> players)
        {
            this.theBoard = new Piece[BOARD_SIZE, BOARD_SIZE];
            this.thePlayers = players;
        }

        /// <summary>
        /// Populates the board with the pieces
        /// </summary>
        private void populateBoard()
        {
            // Each player has a dark square on his far left and a light square on his far right.
            // http://www.jimloy.com/checkers/rules2.htm

            // first player
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                    for (int c = 0; c < 8; c += 2)
                        this.theBoard[i,c] = new Piece(this.thePlayers[0]);

                else
                    for (int c = 1; c < 8; c += 2)
                        this.theBoard[i,c] = new Piece(this.thePlayers[0]);
            }

            // second player
            for (int i = 4; i < 8; i++)
            {
                if (i % 2 == 0)
                    for (int c = 0; c < 8; c += 2)
                        this.theBoard[i, c] = new Piece(this.thePlayers[1]);

                else
                    for (int c = 1; c < 8; c += 2)
                        this.theBoard[i, c] = new Piece(this.thePlayers[1]);
            }
        }

    }
}
