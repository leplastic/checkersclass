using System;
using System.Collections.Generic;

namespace Softklin.Checkers
{


    // TODO create a better implementation of Score card
    // The aim is to allow final users to get the resulst like this
    // scorecard[Player][ScoreType]


    /// <summary>
    /// Represents a score card for the game with nr of victores, draws and defeats
    /// </summary>
    class Score
    {
        #region Variables
        // the score is
        private Dictionary<Player, int[]> scoreCard;

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
            this.scoreCard = new Dictionary<Player, int[]>();
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
                this.scoreCard.Add(player, new int[3] {0,0,0});
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
            {
                switch (type)
                {
                    case ScoreType.VICTORY:
                        this.scoreCard[player][0] += 1;
                        break;

                    case ScoreType.DRAW:
                        this.scoreCard[player][1] += 1;
                        break;

                    case ScoreType.DEFEAT:
                        this.scoreCard[player][2] += 1;
                        break;
                }
            }

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
        /// Returns the actual score card
        /// </summary>
        /// <returns>Score card with the actual results</returns>
        public Dictionary<Player, int[]> getScoreCard()
        {
            return this.scoreCard;
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
