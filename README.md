# Stock Market Game
The aristocrat of money games
# Requirements
- [ ] Players should be able to roll the the dice on their turn
- [ ] Players should be able to 'go to work'
  - [ ] This should be the only option when the game starts
  - [ ] A job consists of 2 numbers between 2 and 12 and a salary
  - [ ] Whenever a roll adds up to one of the two numbers, all players with that job receive that salary
  - [ ] If a player has $1,000 on their pre-turn, they must 'enter the stock market' before rolling
  - [ ] A player may at anytime 'go to work'. This will reset their money and stock to 0.
  - [ ] If a player cannot pay a fee, they must go back to work
- [ ] Players with a job should be able to 'enter the stock market'
  - [ ] Players should be able to enter the stock market at any of 4 squares
    - [ ] All start squares are separated by 11 squares
  - [ ] A square must consist of a player direction
    - [ ] Squares where a player enters the stock market are bidirectional - on odd rolls the direction is left, on even right.
  - [ ] A square may consist of a stock name, a stock dividend, a sell all command, a stockholder entrance, and/or a fee
    - [ ] All squares with fees have 5 squares between them
      - [ ] Start squares have a fee of $100
      - [ ] Squares that are not start squares with a fee have a fee of $10 per share the player owns
      - [ ] Squares that are not start squares with a fee escape to the right
    - [ ] Squares 5 squares away from start squares have a sell all command
    - [ ] Squares 3 squares away from start squares have a stockholder meeting
- [ ] Stock price shall be defined by the Market Index
  - [ ] A stock will be defined by a name, a minimum price, a polarity, and an index multiplier
  - [ ] A stock may be sold by the active player for a price defined by the formula: Minimum price + (Index Multiplier * (Market Index if polarity else (Maximum Market Index - Market Index))
  - [ ] Half of all stocks will have a negative polarity
  - [ ] If the Market Index goes above the Maximum Market Index or below 0, the signed out of bounds portion will be subtracted from the Index
  - [ ] Whenever a player lands on a square with a stock vector, the vector shall be added to the Market Index.
- [ ] Whenever a player lands on a square with a stockholder entrance, if they own that squares stock on their next turn, they will enter the stockholder meeting
  - [ ] Players may only buy one stock at an entrance.
  - [ ] Stockholder meeting squares consist of a stock multiplier
  - [ ] Whenever a player lands on a stock holder meeting square, the amount of the stock that they came into the meeting with that the player owns with be multiplied by the stock multiplier
  - [ ] Stockholder meeting squares are implied to have the player direction that the player came to the square on (thus continuing their journey through the meeting)
- [ ] Whenever a player lands on a square with a stock name and no sell all command, they may buy that stock at the current price
  - [ ] The player losses the ability to buy stock when the next player enters the pre-roll stage
- [ ] Whenever a player lands on a square with a stock name and a stock dividend where the player already owns the stock, the players gains the specified stock dividend for each stock of that name they own
- [ ] When a game is created, a win condition will be supplied
  - [ ] If the win condition is a monetary value, every time the dice is rolled, if the player who rolled the dice could sell all their stocks and have above that value, that player is declared the winner
  - [ ] If the win condition is a minute value, when that amount of game time has passed, whoever has the most money, supposing they were able to sell their stock at the current market value, will be declared the winner.
# Graphics Style Guide
* Clean, single color vector graphics are preferable to pixel art.
* As much as possible, reduce the amount of information that the player has to take in a once
  * For example, by default, the board view should be a ticker tape with only the reachable squares displayed
  * For example, the chart with the stock prices when the stock prices change should be stylistically portrayed, without concrete numbers except for the current, lowest and highest stock price.
