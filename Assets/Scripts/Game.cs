using System;
using System.Collections.Generic;
using UnityEngine;

namespace StockMarketGame
{
    public class Game
    {

        public readonly Board board;

        private Optional<int> valueWinCondition;
        private Optional<float> timeWinCondition;
        private float gameStartTime = 0;

        public List<Player> players = new();

        private int currentPlayerIndex = -1;

        public Game(int valueWinCondition) : this()
        {
            this.valueWinCondition = valueWinCondition;
        }

        public Game(float timeWinCondition) : this()
        {
            this.timeWinCondition = timeWinCondition;
        }

        private Game()
        {
            TextAsset boardJson = (TextAsset)Resources.Load("Board");
            board = JsonUtility.FromJson<Board>(boardJson.text);
        }

        public void StartGame()
        {
            gameStartTime -= Time.realtimeSinceStartup;
            while (!HasGameEnded())
            {
                ExecuteNextTurn();
            }
            EndGame();
        }

        private bool HasGameEnded()
        {
            if (timeWinCondition)
            {
                return timeWinCondition < Time.realtimeSinceStartup - gameStartTime;
            }
            if (valueWinCondition)
            {
                foreach (Player player in players)
                {
                    if (player.GetMonataryValue() > valueWinCondition)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ExecuteNextTurn(Tuple<int, int> rollOverride = null)
        {
            Player player = players[++currentPlayerIndex % players.Count];
            player.OnPreDiceRoll(this);
            player.SetRollingPlayer(this, true);
            Tuple<int, int> roll = rollOverride != null ? rollOverride : new(UnityEngine.Random.Range(1, 7), UnityEngine.Random.Range(1, 7));
            foreach (Player roll_player in players)
            {
                roll_player.OnDiceRoll(this, roll);
            }
            player.OnPostDiceRoll(this);
            player.SetRollingPlayer(this, false);
        }

        private void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}