using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StockMarketGame
{
    public abstract class Player
    {
        protected bool atWork = true;
        public int jobIndex
        {
            get;
            protected set;
        }
        public int cash
        {
            get;
            protected set;
        }
        private int _squareIndex;
        public int squareIndex
        {
            get => _squareIndex;
            set { _squareIndex = ((value %= 48) < 0) ? value + 48 : value; }
        }

        public int GetMonataryValue()
        {
            return cash;
        }

        public abstract void OnPreDiceRoll(Game game);

        public void OnDiceRoll(Game game, Tuple<int, int> roll)
        {
            int rollValue = roll.Item1 + roll.Item2;
            if (atWork)
            {
                Tuple<int, int> jobRolls = game.board.JobIndexToAcceptedRolls(jobIndex);
                if (jobRolls.Item1 == rollValue || jobRolls.Item2 == rollValue)
                {
                    cash += game.board.JobIndexToMoney(jobIndex, 4);
                }
            }
            else
            {
                squareIndex = game.board.IndexToSquare(squareIndex).RollToIndex(this, rollValue);
            }
        }

        public abstract void OnPostDiceRoll(Game game);
        public abstract void SetRollingPlayer(Game game, bool isRoller);
        public abstract int GetSquareIndex();

    }

    public static class PlayerFactory
    {
        public static int lastPlayerIndex = -1;

        public static Color[] colors = {
             Color.red,
             Color.green,
             Color.yellow,
             Color.magenta,
             new Color(255F, 0F, 255F),
             new Color(0F, 255F, 255F),
             new Color(255F, 255F, 0F),
             new Color(128F, 0F, 128F),
             new Color(128F, 0F, 0F)
        };

        public enum PlayerType { Hotseat, AI, Online }

        internal static Player GetPlayer(string nameAndIndex, int proffesionIndex)
        {
            while (int.TryParse(nameAndIndex[nameAndIndex.Length - 1].ToString(), out int result))
            {
                nameAndIndex = nameAndIndex.Substring(0, nameAndIndex.Length - 1);
            }
            PlayerType playerType = Enum.Parse<PlayerType>(nameAndIndex);
            switch (playerType)
            {
                case PlayerType.Hotseat:
                    return new LocalPlayer(proffesionIndex);
                case PlayerType.AI:
                    return new AIPlayer(proffesionIndex);
                case PlayerType.Online:
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public class LocalPlayer : Player
    {
        public LocalPlayer(int jobIndex)
        {
            this.jobIndex = jobIndex;
        }

        public override int GetSquareIndex()
        {
            throw new NotImplementedException();
        }

        public override void OnPostDiceRoll(Game game)
        {
            throw new NotImplementedException();
        }

        public override void OnPreDiceRoll(Game game)
        {
            throw new NotImplementedException();
        }

        public override void SetRollingPlayer(Game game, bool isRoller)
        {
            throw new NotImplementedException();
        }
    }

    public class AIPlayer : Player
    {
        public AIPlayer(int jobIndex)
        {
            this.jobIndex = jobIndex;
        }

        public override int GetSquareIndex()
        {
            throw new NotImplementedException();
        }



        public override void OnPostDiceRoll(Game game)
        {
            //throw new NotImplementedException();
        }

        public override void OnPreDiceRoll(Game game)
        {
            if (atWork && cash > 1000)
            {
                atWork = false;
            }
        }

        public override void SetRollingPlayer(Game game, bool isRoller)
        {
            //throw new NotImplementedException();
        }
    }
}
