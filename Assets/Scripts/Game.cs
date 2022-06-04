using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game {
    private const int maximumMarketIndex = 29;

    public int marketIndex {
        set => _marketIndex = ClampMarketIndex(value);
        get => _marketIndex;
    }

    private int _marketIndex;

    public class Square {
        public bool forward;
        public int stockChange;
        public Stock stock;
        public bool forcedSell;
        /// <summary>
        /// Is this none stock on the the coner or the edge?
        /// </summary>
        public bool brokerFee;
    }

    private IPlayer[] players;

    private int ClampMarketIndex(int value) {
        if (value > maximumMarketIndex)
        {
            return ClampMarketIndex(maximumMarketIndex - (value - maximumMarketIndex));
        }
        else if (value < 0)
        {
            return ClampMarketIndex(-value);
        }
        return value;
    }

    public Game(int moneyWinCondition, IPlayer[] players) {
        this.players = players;
    }

    public Game(float timeWinCondition, IPlayer[] players) {
        this.players = players;
    }

    private Tuple<int, int> RollDice() {
        throw new NotImplementedException();
    }

    public int StockToCurrentPrice(Stock stock) {
        throw new NotImplementedException();
    }

    public int StockToMinimumPrice(Stock stock) {
        throw new NotImplementedException();
    }
}


