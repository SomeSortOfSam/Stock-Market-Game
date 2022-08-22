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
        public NamedSquare[] squares;

        public abstract class Square
        {
            public abstract int RollToIndex(Player player, int rollValue);
        }

        public abstract class FeeSquare : Square
        {
            public abstract int GetFeeAmount(Player player);
        }

        public class StartSquare : FeeSquare
        {
            public override int GetFeeAmount(Player player)
            {
                return 100;
            }

            public override int RollToIndex(Player player, int rollValue)
            {
                return (player.squareIndex + rollValue * (rollValue % 2 == 0 ? 1 : -1));
            }
        }

        public class CornerSquare : FeeSquare
        {
            public override int GetFeeAmount(Player player)
            {
                throw new NotImplementedException();
            }

            public override int RollToIndex(Player player, int rollValue)
            {
                return player.squareIndex + rollValue;
            }
        }

        [Serializable]
        public class NamedSquare : Square
        {
            [SerializeField]
            public bool directionIsRight;
            [SerializeField]
            public int stockIndex;
            [SerializeField]
            public int stockVector;

            public override int RollToIndex(Player player, int rollValue)
            {
                return player.squareIndex + rollValue * (directionIsRight ? 1 : -1);
            }


        }

        public class StockholderSquare : NamedSquare
        {
            public StockholderSquare(NamedSquare square)
            {
                directionIsRight = square.directionIsRight;
                stockIndex = square.stockIndex;
                stockVector = square.stockVector;
            }

            public override int RollToIndex(Player player, int rollValue)
            {
                throw new NotImplementedException();
            }
        }

        [Serializable]
        public struct Stock
        {
            [SerializeField]
            private int minimumValue;
            [SerializeField]
            private int marketIndexMultiplier;
        }

        public int JobIndexToMoney(int index, int maxIndex) => jobMultipler * (maxIndex - index);

        public Tuple<int, int> JobIndexToAcceptedRolls(int index) => new(index + 2, 12 - index);

        public Square IndexToSquare(int index)
        {
            if (index % 12 == 0)
            {
                return new StartSquare();
            }
            else if ((index - 6) % 12 == 0)
            {
                return new CornerSquare();
            }
            else
            {
                int squareIndex = (int)(index - (index / 5.5f) - 1);
                NamedSquare square = squares[squareIndex];
                if ((index - 3) % 6 == 0)
                {
                    return new StockholderSquare(square);
                }
                else
                {
                    return square;
                }
            }
        }
    }
}