using System;
using System.Collections.Generic;

namespace Softklin.Checkers
{
    /// <summary>
    /// Represents a score card for the game with nr of victores, draws and defeats
    /// </summary>
    class Score
    {
        #region Variables

        private Dictionary<Player, Dictionary<ScoreType, int>> scoreCard;

        #endregion


        #region Properties

        /// <summary>
        /// Indicates whenever the score card it's locked or not.
        /// A locked score card means that any scores added will be ignored
        /// </summary>
        public bool LockedScores { get; set; }

        #endregion


        /// <summary>
        /// Creates a new score card
        /// </summary>
        public Score()
        {
            this.scoreCard = new Dictionary<Player, Dictionary<ScoreType, int>>();
        }

        /// <summary>
        /// Gets the curent score for a player
        /// </summary>
        /// <param name="p">The player</param>
        /// <returns>Player's score</returns>
        public Dictionary<ScoreType, int> this[Player p]
	    {
            get { return this.scoreCard[p]; }
            private set { this.scoreCard[p] = value; }
	    }

        /// <summary>
        /// Adds a player to the score card.
        /// </summary>
        /// <param name="player">The player to add</param>
        /// <remarks>
        /// Each player starts with 0 (zero) points.
        /// If the player is already in the score card, nothing is done.
        /// If the score card is locked, the player won't be added.
        /// </remarks>
        public void addPlayer(Player player)
        {
            if (!this.LockedScores && !this.scoreCard.ContainsKey(player))
            {
                Dictionary<ScoreType, int> points = new Dictionary<ScoreType, int>(3);
                points.Add(ScoreType.VICTORY, 0);
                points.Add(ScoreType.DRAW, 0);
                points.Add(ScoreType.DEFEAT, 0);

                this.scoreCard.Add(player, points);
            }
        }

        /// <summary>
        /// Sets a victory, draw or defeat to the player's score
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="type">Score type to assign</param>
        /// <remarks>
        /// To assign multiple scores of one type, see the overload method with the count parameter.
        /// </remarks>
        public void addScore(Player player, ScoreType type)
        {
            addPlayer(player);

            if (!this.LockedScores)
                this.scoreCard[player][type] += 1;

        }

        /// <summary>
        /// Sets a victory, draw or defeat to the player's score
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="type">Score type to assign</param>
        /// <param name="count">Number of times to add the score</param>
        public void addScore(Player player, ScoreType type, int count)
        {
            if (!this.LockedScores)
                for (int i = 0; i < count; i++)
                    addScore(player, type);
        }

        /// <summary>
        /// Merges two score cards and returns the new one
        /// </summary>
        /// <param name="otherScore">The other score card</param>
        /// <returns>New core card with the result of merge</returns>
        /// <remarks>
        /// The score cards won't be modified.
        /// Instead, a new score card will be created, and the results copied to the new one
        /// </remarks>
        public Score mergeScores(Score otherScore)
        {
            Score result = new Score();
            result.scoreCard = this.scoreCard;

            foreach (Player p in otherScore.scoreCard.Keys)
            {
                Dictionary<ScoreType, int> points = otherScore.scoreCard[p];
                result.addScore(p, ScoreType.VICTORY, points[ScoreType.VICTORY]);
                result.addScore(p, ScoreType.DRAW, points[ScoreType.DRAW]);
                result.addScore(p, ScoreType.DEFEAT, points[ScoreType.DEFEAT]);
            }

            return result;
        }
    }


    /// <summary>
    /// Represents score types for the score card
    /// </summary>
    enum ScoreType
    {
        /// <summary>
        /// Represents a player's victory
        /// </summary>
        VICTORY,

        /// <summary>
        /// Represents a player's draw
        /// </summary>
        DRAW,

        /// <summary>
        /// Represents a player's defeat
        /// </summary>
        DEFEAT
    }
}
