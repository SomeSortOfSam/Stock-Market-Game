using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

namespace StockMarketGame
{
    public class Lobby : ProffesionalContext
    {
        [Space]
        [SerializeField]
        private TextMeshProUGUI hostingText;
        [SerializeField]
        private RectTransform hostingOptionsContainer;
        public bool onHostMachine = true;

        private UnityEvent<IEnumerable<IPlayer>> RequestStartGameEvent = new UnityEvent<IEnumerable<IPlayer>>();


        public override void Start()
        {
            base.Start();
            hostingOptionsContainer.gameObject.SetActive(false);
        }

        public override void OnTickerTapeAnimationFinished(Game game)
        {
            base.OnTickerTapeAnimationFinished(game);
            if (onHostMachine)
            {
                StartCoroutine(ShowHostControlsCoruotine());
            }
        }

        private IEnumerator ShowHostControlsCoruotine()
        {
            hostingOptionsContainer.gameObject.SetActive(true);
            hostingOptionsContainer.offsetMax = Vector2.zero;
            for (float i = 0; i < 48; i++)
            {
                Vector2 max = hostingOptionsContainer.offsetMax;
                max.y = (i / 48f) * 100;
                hostingOptionsContainer.offsetMax = max;
                yield return null;
            }
            hostingOptionsContainer.offsetMax = new Vector2(0, 100);
        }

        public void OnAIAdded()
        {
            int randi = UnityEngine.Random.Range(0, professionContainer.childCount);
            professionContainer.GetChild(randi).GetComponent<ProffesionButton>().AddPlayer(PlayerFactory.PlayerType.AI);
        }

        public void OnStartGame()
        {
            List<IPlayer> players = new List<IPlayer>();
            for (int i = 0; i < professionContainer.childCount; i++)
            {
                Transform child = professionContainer.GetChild(i);
                IEnumerable<IPlayer> buttonPlayers = child.GetComponent<ProffesionButton>().GetPlayers();
                players.AddRange(buttonPlayers);
            }
            RequestStartGameEvent.Invoke(players);
        }

        public override void SubscribeToEvents(GameManager subscriber)
        {
            base.SubscribeToEvents(subscriber);
            RequestStartGameEvent.AddListener(subscriber.OnStartGameRequested);
        }

    }
}