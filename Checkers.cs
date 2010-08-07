using System;
using System.Collections.Generic;

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
        /// <remarks>
        /// The nickname should be unique
        /// </remarks>
        public static Player createPlayer(string nickname, string realname)
        {
            return new Player(nickname, realname);
        }
        
        /// <summary>
        /// Creates a new game
        /// </summary>
        /// <param name="player1">The player 1 instance</param>
        /// <param name="player2">The player 2 instance</param>
        /// <param name="useGameLog">Allows the game to use the built-in game log feature or not</param>
        /// <returns>An instance of a newly created game</returns>
        public static Game createGame(Player player1, Player player2, bool useGameLog)
        {
            return new Game(player1, player2, useGameLog);
        }


    }
}
