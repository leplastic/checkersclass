using System;
using System.Collections.Generic;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a full game log
    /// </summary>
    class GameLog
    {
        private List<GameLogEntry> theLog;

        public GameLog()
        {
            this.theLog = new List<GameLogEntry>();
        }

        public void logEvent(GameLogEntry glo)
        {
            this.theLog.Add(glo);
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
