using System;

namespace Softklin.Checkers
{
    /// <summary>
    /// Allows you to create all needed elementos to start a checkers game
    /// </summary>
    /// <remarks>
    /// This class is a factory. You should create your instances of game elements through this class.
    /// </remarks>
    public class Checkers
    {
        /// <summary>
        /// Creates a new Player
        /// </summary>
        /// <param name="nickname">The player's nickname</param>
        /// <param name="realname">The player's realname</param>
        /// <returns>An instance of new player</returns>
        public static Player createPlayer(string nickname, string realname)
        {
            return new Player(nickname, realname);
        }
        
        /// <summary>
        /// Creates a new game, using the built-in game log feature
        /// </summary>
        /// <param name="player1">The player 1 instance</param>
        /// <param name="player2">The player 2 instance</param>
        /// <param name="translationTable">The Translation table to use in the game</param>
        /// <returns>An instance of a newly created game</returns>
        /// <remarks>
        /// The players should not use the same nickname (they can't be the same player)
        /// </remarks>
        public static Game createGame(Player player1, Player player2, GameLogTranslation translationTable)
        {
            return new Game(player1, player2, translationTable);
        }

        /// <summary>
        /// Creates a new game without built-in game log feature
        /// </summary>
        /// <param name="player1">The player 1 instance</param>
        /// <param name="player2">The player 2 instance</param>
        /// <returns>An instance of a newly created game</returns>
        /// <remarks>
        /// The players should not use the same nickname (they can't be the same player)
        /// </remarks>
        public static Game createGame(Player player1, Player player2)
        {
            return new Game(player1, player2);
        }

        /// <summary>
        /// Creates an empty translation table for use with game log feature
        /// </summary>
        /// <param name="languageCode">Any code to future reference</param>
        /// <returns>New translation table</returns>
        /// <remarks>
        /// <para>The translation table is only needed if it's intended to use
        /// the built-in game log feature.</para>
        /// <para>The translation table must be populated before used</para>
        /// </remarks>
        public static GameLogTranslation createTranslationTable(string languageCode)
        {
            return new GameLogTranslation(languageCode);
        }

        /// <summary>
        /// Creates a game log translation table already populated with english sentences
        /// </summary>
        /// <returns>Populated game log translation table</returns>
        public static GameLogTranslation createDefaultTranslationTable()
        {
            GameLogTranslation glt = new GameLogTranslation("EN");

            // TODO Populate the translation table with default english sentences

            return glt;
        }
    }
}
