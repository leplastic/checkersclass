using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a full game log
    /// </summary>
    public class GameLog
    {
        #region Variables

        private List<GameLogEntry> theLog;
        private DateTime startTime;
        private GameLogTranslation translations;

        #endregion

        /// <summary>
        /// Creates a new game log
        /// </summary>
        private GameLog()
        {
            this.theLog = new List<GameLogEntry>();
            this.startTime = DateTime.Now;
        }

        /// <summary>
        /// Creates a new game log with a translation table
        /// </summary>
        /// <param name="i18nTable">The trasnlation table to use</param>
        internal GameLog(GameLogTranslation i18nTable) : this()
        {
            this.translations = i18nTable;
        }

        /// <summary>
        /// Adds a new log entry
        /// </summary>
        /// <param name="glo">The log entry to add</param>
        internal void logEvent(GameLogEntry glo)
        {
            try
            {
                glo.Message = this.translations[glo.Type];
                this.theLog.Add(glo);
            }
            catch (Exception e)
            {
                throw new CheckersGameLogException("Translation missing", e);
            }
        }

        /// <summary>
        /// Gets the events according a certain time interval, sorted by time (ascending)
        /// </summary>
        /// <param name="from">Lower time limit</param>
        /// <param name="to">Higher time limit</param>
        /// <returns>Filtered game log</returns>
        /// <remarks>
        /// If the <c>from</c> date is greater than the <c>to</c> date
        /// the result will be an empty list
        /// </remarks>
        public List<GameLogEntry> getEntries(DateTime from, DateTime to)
        {
            this.theLog.Sort();
            List<GameLogEntry> result = new List<GameLogEntry>();

            foreach (GameLogEntry glo in this.theLog)
                if (glo.Time >= from && glo.Time <= to)
                    result.Add(glo);

            return result;
        }

        /// <summary>
        /// Returns a complete copy of the log sorted by time (ascending)
        /// </summary>
        /// <returns>Entire log of the game</returns>
        public List<GameLogEntry> getAllEntries()
        {
            this.theLog.Sort();
            return this.theLog;
        }
    }


    /// <summary>
    /// Represents a generic entry in the game log
    /// </summary>
    public class GameLogEntry : IComparable
    {
        private string translatedMessage;


        #region Properties

        /// <summary>
        /// Type of log entry
        /// </summary>
        public LogEntryType Type { get; internal set; }

        /// <summary>
        /// The time which the event occured
        /// </summary>
        public DateTime Time { get; internal set; }

        /// <summary>
        /// Gets the message from the log entry
        /// </summary>
        public string Message {
            get
            {
                return this.translatedMessage;
            }

            internal set
            {
                this.translatedMessage = translateFromContext(value);
            }
        }

        /// <summary>
        /// Game context information
        /// </summary>
        internal GameContext Context { get; set; }

        #endregion


        /// <summary>
        /// Creates a new generic game log entry
        /// </summary>
        /// <param name="time">The current/real time</param>
        internal GameLogEntry(DateTime time)
        {
            this.Time = time;
            this.Context = new GameContext();
        }

        /// <summary>
        /// Creates a final context-based message to log
        /// </summary>
        /// <param name="s">The already translated sentence with placeholders</param>
        /// <returns>Complete log message</returns>
        private string translateFromContext(string sentence)
        {
            // TODO Method stub for translateFromContext
            return "";
        }

        public int CompareTo(object obj)
        {
            if (!(obj is GameLogEntry))
                throw new ArgumentException("obj is not a GameLogEntry");

            GameLogEntry glo = (GameLogEntry) obj;

            return this.Time.CompareTo(glo.Time);
        }
    }


    /// <summary>
    /// Represents a translation table
    /// </summary>
    public class GameLogTranslation
    {
        private Dictionary<LogEntryType, String> translations;

        
        #region Properties

        /// <summary>
        /// Gets the defined language code for this translation table
        /// </summary>
        public string LanguageCode { get; internal set; }

        #endregion


        /// <summary>
        /// Creates a new translation table
        /// </summary>
        internal GameLogTranslation(string code)
        {
            this.translations = new Dictionary<LogEntryType, string>();
            this.LanguageCode = code;
        }

        /// <summary>
        /// Allow the access to a translation string by it's type
        /// </summary>
        /// <param name="type">The type of game log entry</param>
        /// <returns>String for the specified game log entry type</returns>
        public String this[LogEntryType type]
        {
            get
            {
                return this.translations[type];
            }

            set
            {
                if (!this.translations.ContainsKey(type))
                    this.translations.Add(type, value);

                else
                    this.translations[type] = value;
            }
        }
    }


    /// <summary>
    /// Represents a current game context for logging purposes
    /// </summary>
    struct GameContext
    {
        /// <summary>
        /// Players in the related context
        /// </summary>
        internal Player[] Players { get; set; }

        /// <summary>
        /// The source location of the piece we're moving
        /// </summary>
        internal PieceLocation SourceLocation { get; set; }

        /// <summary>
        /// Destination location of the piece we're moving
        /// </summary>
        internal PieceLocation DestinationLocation { get; set; }

        /// <summary>
        /// The piece to move
        /// </summary>
        internal Piece BoardPiece { get; set; }
    }


    /// <summary>
    /// Type of game log entry
    /// </summary>
    public enum LogEntryType
    {
        GAME_START,
        GAME_END,
        VICTORY,
        DRAW,
        PLAYER_TURN,
        PIECE_MOVE,
        PIECE_QUEEN,
        PIECE_EAT
    }


    [Serializable]
    public class CheckersGameLogException : Exception
    {
        public CheckersGameLogException() { }
        public CheckersGameLogException(string message) : base(message) { }
        public CheckersGameLogException(string message, Exception inner) : base(message, inner) { }
        protected CheckersGameLogException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
