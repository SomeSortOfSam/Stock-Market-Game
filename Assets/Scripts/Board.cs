using System;
using UnityEngine;

namespace StockMarketGame
{
    [Serializable]
    public struct Board
    {
        [SerializeField]
        private int startingMoney;
        [SerializeField]
        public int jobMultipler { get; private set; }
        [SerializeField]
        private int maximumMarketIndex;
        [SerializeField]
        private int startFee;
        [SerializeField]
        private int fee;

        [SerializeField]
        private Stock[] stocks;
        [SerializeField]
        private int[][] stockholderSquares;
        [SerializeField]
        private Square[][] squares;

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