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

        #endregion

        /// <summary>
        /// Creates a new game log
        /// </summary>
        public GameLog()
        {
            this.theLog = new List<GameLogEntry>();
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
    /// Represents an entry in the game log
    /// </summary>
    class GameLogEntry
    {
        private DateTime time;
        private LogEntryType type;

    }

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
