using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StockMarketGame
{
    internal interface IPlayer
    {
        int GetJobIndex();
        void OnPreDiceRoll(Game game);
        void OnDiceRoll(Game game, System.Tuple<int, int> roll);
        void OnPostDiceRoll(Game game);
        void SetRollingPlayer(Game game, bool isRoller);
        int GetSquareIndex();
    }

    internal static class PlayerFactory
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

        internal static IPlayer GetPlayer(string nameAndIndex, int proffesionIndex)
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
                case PlayerType.Online:
                default:
                    throw new NotImplementedException();
            }
        }
    }

    internal class LocalPlayer : IPlayer
    {
        public LocalPlayer(int jobIndex)
        {
            this.jobIndex = jobIndex;
        }

        private int jobIndex = 0;
        public int GetJobIndex() => jobIndex;
        public int GetSquareIndex()
        {
            throw new NotImplementedException();
        }

        public void OnDiceRoll(Game game, Tuple<int, int> roll)
        {
            throw new NotImplementedException();
        }

        public void OnPostDiceRoll(Game game)
        {
            throw new NotImplementedException();
        }

        public void OnPreDiceRoll(Game game)
        {
            throw new NotImplementedException();
        }

        public void SetRollingPlayer(Game game, bool isRoller)
        {
            throw new NotImplementedException();
        }
    }

}
