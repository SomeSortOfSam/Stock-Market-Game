using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StockMarketGame
{
    internal interface IPlayer
    {
        void OnPreDiceRoll(Game game);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        void OnDiceRoll(Game game, System.Tuple<int, int> roll);
        void OnPostDiceRoll(Game game);
        void SetRollingPlayer(Game game, bool isRoller);
        int GetSquareIndex();
    }

    internal class LocalPlayer : IPlayer
    {
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
            throw new System.NotImplementedException();
        }

        public void OnPreDiceRoll(Game game)
        {
            throw new System.NotImplementedException();
        }

        public void SetRollingPlayer(Game game, bool isRoller)
        {
            throw new System.NotImplementedException();
        }
    }
}
