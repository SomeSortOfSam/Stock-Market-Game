using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public enum Stock
    {
        None,
        Alcoa,
        AmericanMotors,
        JICase,
        GeneralMills,
        IntShoe,
        Maytag,
        WesternPubl,
        Woolworth
    }
    public struct Square
    {
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

    private Tuple<int, int> RollDice()
    {
        throw new NotImplementedException();
    }

    public int StockToCurrentPrice(Stock stock)
    {
        throw new NotImplementedException();
    }

    public int StockToMinumumPrice(Stock stock)
    {
        throw new NotImplementedException();
    }
}


