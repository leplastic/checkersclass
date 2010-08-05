using System;
using System.Collections.Generic;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a single checkers game
    /// </summary>
    public class Game
    {
        #region Delegates and Events

        /// <summary>
        /// Occurs when the game starts
        /// </summary>
        public event GameStartedEvent GameStarted;
        public delegate void GameStartedEvent(Player firstPlayer);

        #endregion

        #region Variables

        private Board theBoard;
        private GameLog theLog;
        private List<Player> thePlayers;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates the game state
        /// </summary>
        public GameState GameStatus { get; private set; }

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
            this.thePlayers[0] = player1;
            this.thePlayers[1] = player2;
            this.theBoard = new Board(this.thePlayers);
            this.GameStatus = GameState.NOT_STARTED;
        }

        /// <summary>
        /// Starts the game. The first player will be choosen randomly.
        /// </summary>
        /// <remarks>
        /// As the checkers game has two players, the random factor is based on even/odd,
        /// so both the players have equal oportunity to start the game.
        /// </remarks>
        public void startGame()
        {
            Random r = new Random();
            int n = r.Next(1, 10);

            Player who = this.thePlayers[n % 2];
            this.GameStatus = GameState.RUNNING;
            GameStarted(who);
        }

        /// <summary>
        /// Starts the game. The chosen player will be the first to play
        /// </summary>
        /// <param name="first">The fisrt player to play</param>
        public void startGame(Player first)
        {
            if (!this.thePlayers.Contains(first))
                throw new CheckersGameException("The first player doesn't exists");

            this.GameStatus = GameState.RUNNING;
            GameStarted(first);
        }
    }


    /// <summary>
    /// Represents the current game status
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// The game was not started yet
        /// </summary>
        NOT_STARTED,

        /// <summary>
        /// The game is currently running
        /// </summary>
        RUNNING,

        /// <summary>
        /// The game already ended due a victory or draw
        /// </summary>
        ENDED
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
