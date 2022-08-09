using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StockMarketGame
{
    [RequireComponent(typeof(Button))]
    public class ProffesionButton : MonoBehaviour
    {
        [SerializeField]
        private Transform playerIconHolder;

        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(AddPlayer);
        }

        private void AddPlayer()
        {
            AddPlayer(PlayerFactory.PlayerType.Hotseat);
        }

        internal void AddPlayer(PlayerFactory.PlayerType playerType)
        {
            GameObject image = new GameObject(playerType.ToString() + playerIconHolder.childCount, typeof(Image), typeof(AspectRatioFitter));
            image.transform.SetParent(playerIconHolder);
            GameObject template = (GameObject)Resources.Load("vectors/" + playerType.ToString());
            Sprite texture = template.GetComponent<SpriteRenderer>().sprite;
            if (image.TryGetComponent(out Image sprite))
            {
                sprite.sprite = texture;
                sprite.useSpriteMesh = true;
                sprite.color = PlayerFactory.colors[++PlayerFactory.lastPlayerIndex];
            }
            if (TryGetComponent(out AspectRatioFitter fitter))
            {
                fitter.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
                fitter.aspectRatio = .6f;
            }
        }

        internal IEnumerable<IPlayer> GetPlayers()
        {
            List<IPlayer> players = new List<IPlayer>();
            for (int i = 0; i < playerIconHolder.childCount; i++)
            {
                Transform proffesion = playerIconHolder.GetChild(i);
                players.Add(PlayerFactory.GetPlayer(proffesion.gameObject.name, transform.GetSiblingIndex()));
            }
            return players;
        }

    }
}
