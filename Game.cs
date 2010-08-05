using System;
using System.Collections.Generic;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a single checkers game
    /// </summary>
    public class Game
    {
        #region Variables

        private Board theBoard;
        private GameLog theLog;
        private List<Player> thePlayers;

        #endregion

        /// <summary>
        /// Creates a new game with two players
        /// </summary>
        /// <param name="player1">The player 1</param>
        /// <param name="player2">The player 2</param>
        public Game(Player player1, Player player2)
        {
            if (player1 == null || player2 == null)
                throw new CheckersGameException("Instance of player1/2 required");

            if (player1.Equals(player2))
                throw new CheckersGameException("The players cannot be equal");

            this.theLog = new GameLog();
            this.thePlayers = new List<Player>(2);
            this.thePlayers.Add(player1);
            this.thePlayers.Add(player2);
            this.theBoard = new Board(this.thePlayers);
        }
    }


    /// <summary>
    /// Checkers Game Exception
    /// </summary>
    [Serializable]
    public class CheckersGameException : Exception
    {
        public CheckersGameException() { }
        public CheckersGameException(string message) : base(message) { }
        public CheckersGameException(string message, Exception inner) : base(message, inner) { }
        protected CheckersGameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
