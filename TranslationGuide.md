
---

NOTE: This documentation and all items described here can be changed at any time. Right now, it's for informative purposes only!

---


# Introduction #

The GameLog feature allows the developer to translate the messages to any language. This is possible because an object called `GameLogTranslation` maintains all translations of each gamelog entry type, with some special wildcards called placeholders. These placeholders will be internally changed by the final values.

Eg, suppose we're translating the entry corresponding to a victory. It could be something like this:

The player {%player} won the game!

In this case, our placeholder is {%player} which will be changed internally by the player who won the game.


## Using the `GameLogTranslation` class ##

To be done.

## Placeholder List ##

Note: All placeholders are context sensitive. Eg, in the player1's turn, he/she will be the 'player' and the player2 will be the 'opponent', and vice-versa for player2's turn.

| **Placeholder**  | **Meaning** |
|:-----------------|:------------|
| {%player}      | Current player for the actual turn |
| {%opponent}    | The other player (opponent) for the actual player's turn |
| {%location}    | The location of current piece in the board |
| {%destination} | The place where the current piece jumps/will jump to |