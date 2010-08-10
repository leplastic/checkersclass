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

        /// <summary>
        /// Occurs when the turns changes
        /// </summary>
        /// <remarks>
        /// This event is not raised when the game starts (eg. changing the turn for the fisrt player). 
        /// When the first player's turn end, and for the next ones, this event will be raised normally
        /// </remarks>
        public event ChangedTurnEvent ChangedTurn;
        public delegate void ChangedTurnEvent(Player nextPlayer);

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

        /// <summary>
        /// Gets the current score card
        /// </summary>
        public Score ScoreCard { get; private set; }

        /// <summary>
        /// Gets the player who will play (next turn or next move)
        /// </summary>
        public Player NextPlayer { get; private set; }

        #endregion


        /// <summary>
        /// Creates a new game with two players
        /// </summary>
        /// <param name="player1">The player 1</param>
        /// <param name="player2">The player 2</param>
        /// <param name="allowLogging">Enable the gamelog feature or not</param>
        /// <remarks>
        /// Once enabled, the gamelog cannot be stopped.
        /// Also, if disabled by default, it's not possible to enable it when the game is running.
        /// </remarks>
        internal Game(Player player1, Player player2, bool allowLogging)
        {
            if (player1 == null || player2 == null)
                throw new CheckersGameException("Instance of player1 and player 2 required");

            if (player1.Equals(player2))
                throw new CheckersGameException("The players cannot be equal");

            if (allowLogging)
                this.theLog = new GameLog();

            this.thePlayers = new List<Player>(2);
            this.thePlayers.Add(player1);
            this.thePlayers.Add(player2);
            this.theBoard = new Board(this.thePlayers);
            this.GameStatus = GameState.NOT_STARTED;
            this.ScoreCard = new Score(this.thePlayers);
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
            this.NextPlayer = who;
            GameStarted(who);
        }

        /// <summary>
        /// Starts the game. The chosen player will be the first to play
        /// </summary>
        /// <param name="first">The fisrt player to play</param>
        public void startGame(Player first)
        {
            if (this.GameStatus != GameState.NOT_STARTED)
                throw new CheckersGameException("The game already started or ended. Please start a new game instead");

            if (!this.thePlayers.Contains(first))
                throw new CheckersGameException("The first player doesn't exists in this game");

            this.GameStatus = GameState.RUNNING;
            this.NextPlayer = first;
            GameStarted(first);
        }

        /// <summary>
        /// Generates a position cache for clients
        /// </summary>
        /// <returns>Position cache of all pieces</returns>
        /// <remarks>
        /// You can call this method at any time you need to know the current piece position.
        /// Although this method supports multiple access with a thread,
        /// it's recomeended that you only get information when the game changes (eg, a move occurs,
        /// or the player's turn ends), through the game events
        /// </remarks>
        public PositionStatus[,] getPiecesPosition()
        {
            return this.theBoard.getPiecesPosition();
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
        /// The game is currently paused
        /// </summary>
        /// <remarks>
        /// Not implemented. Reserved for future use
        /// </remarks>
        PAUSED,

        /// <summary>
        /// The game already ended due a victory or draw
        /// </summary>
        ENDED
    }


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
