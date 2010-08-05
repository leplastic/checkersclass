using System;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a player in checkers game
    /// </summary>
    public class Player
    {
        #region Properties

        /// <summary>
        /// The player's nickname
        /// </summary>
        public string Nickname { get; private set; }

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
            if (nickname == null || nickname == String.Empty)
                throw new CheckersPlayerException("Nickname cannot be null or empty");

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


    [Serializable]
    public class CheckersPlayerException : Exception
    {
        public CheckersPlayerException() { }
        public CheckersPlayerException(string message) : base(message) { }
        public CheckersPlayerException(string message, Exception inner) : base(message, inner) { }
        protected CheckersPlayerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
