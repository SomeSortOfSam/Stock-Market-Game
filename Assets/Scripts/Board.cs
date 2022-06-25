using System;
using System.Collections.Generic;
using UnityEngine;

namespace StockMarketGame
{
    [Serializable]
    public struct Board
    {
        public int startingMoney;
        public int jobMultipler;
        public int maximumMarketIndex;
        public int startFee;
        public int fee;

        public Stock[] stocks;
        public int stockholderSquaresLength;
        public int[] stockholderSquares;
        public int startToCornerDistance;
        public Square[] squares;

        [Serializable]
        public struct Square
        {
            [SerializeField]
            private bool directionIsRight;
            [SerializeField]
            private int stockIndex;
            [SerializeField]
            private int stockVector;
        }

        [Serializable]
        public struct Stock
        {
            [SerializeField]
            private int minimumValue;
            [SerializeField]
            private int marketIndexMultiplier;
        }
    }
}