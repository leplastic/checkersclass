using System;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a player in checkers game
    /// </summary>
    class Player
    {
        #region Properties

        /// <summary>
        /// The player's nickname
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// The player's real name
        /// </summary>
        public string RealName { get; set; }

        #endregion


        /// <summary>
        /// Creates a new player
        /// </summary>
        /// <param name="nickname">The player's nickname</param>
        /// <param name="realName">The player's real name</param>
        /// <example>Player p = new Player("mycoolnick", "John Big");</example>
        public Player(string nickname, string realName)
        {
            this.Nickname = nickname;
            this.RealName = realName;
        }


        #region Overrides

        public override bool Equals(object obj)
        {
            return (obj.GetType().Equals(this.GetType()) && ((Player) obj).Nickname == this.Nickname);
        }

        public override int GetHashCode()
        {
            return this.Nickname.GetHashCode();
        }

        #endregion
    }
}
