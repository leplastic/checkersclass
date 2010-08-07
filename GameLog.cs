using System;
using System.Collections.Generic;

namespace Softklin.Checkers
{


    // TODO Fix the follow
    // This is a mess. Need to check for different log entries, and
    // make each log to accept the right number os arguments
    // for each situation


    /// <summary>
    /// Represents a full game log
    /// </summary>
    class GameLog
    {
        #region Variables

        private List<GameLogEntry> theLog;
        private DateTime startTime;

        #endregion

        /// <summary>
        /// Creates a new game log
        /// </summary>
        public GameLog()
        {
            this.theLog = new List<GameLogEntry>();
            this.startTime = DateTime.Now;
        }

        /// <summary>
        /// Adds a new log entry
        /// </summary>
        /// <param name="glo">The log entry to add</param>
        public void logEvent(GameLogEntry glo)
        {
            this.theLog.Add(glo);
        }

        public List<GameLogEntry> getEntries(DateTime from, DateTime to)
        {
            return null;
        }

        /// <summary>
        /// Returns a complete copy of the log
        /// </summary>
        /// <returns>Entire log of the game</returns>
        public List<GameLogEntry> getAllEntries()
        {
            return this.theLog;
        }
    }


    /// <summary>
    /// Represents a generic entry in the game log
    /// </summary>
    class GameLogEntry
    {
        public LogEntryType Type { get; internal set; }
        public DateTime Time { get; internal set; }

        /// <summary>
        /// Creates a new generic game log entry
        /// </summary>
        /// <param name="time">The current/real time</param>
        public GameLogEntry(DateTime time)
        {
            this.Time = time;
        }
    }


    /// <summary>
    /// Represents a log entry indicating that the game started
    /// </summary>
    class GameStartLogEntry : GameLogEntry
    {
        private Player p;

        /// <summary>
        /// Creates a new game log entry
        /// </summary>
        /// <param name="firstPlayer">The first player to play</param>
        public GameStartLogEntry(Player firstPlayer) : base(DateTime.Now)
        {
            base.Type = LogEntryType.GAME_START;
            this.p = firstPlayer;
        }
    }


    /// <summary>
    /// Represents a log entry indicating that the game ended
    /// </summary>
    class GameEndLogEntry : GameLogEntry
    {
        public GameEndLogEntry(Player firstPlayer) : base(DateTime.Now)
        {
            base.Type = LogEntryType.GAME_END;
        }
    }


    // TODO Create more classes for other cases below...


    /// <summary>
    /// Type of game log entry
    /// </summary>
    enum LogEntryType
    {
        GAME_START,
        GAME_END,
        VICTORY,
        DEFEAT,
        DRAW,
        PLAYER_TURN,
        PLAYER_PASS,
        PIECE_MOVE,
        PIECE_QUEEN,
        PIECE_EAT
    }
}
