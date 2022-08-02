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

        public enum PlayerType { Hotseat, AI, Online }

        // Start is called before the first frame update
        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(AddPlayer);
        }

        private void AddPlayer()
        {
            AddPlayer(PlayerType.Hotseat);
        }

        public void AddPlayer(PlayerType playerType)
        {
            GameObject image = new GameObject(playerType.ToString() + playerIconHolder.childCount, typeof(Image), typeof(AspectRatioFitter));
            image.transform.SetParent(playerIconHolder);
            GameObject template = (GameObject)Resources.Load("vectors/" + playerType.ToString());
            Sprite texture = template.GetComponent<SpriteRenderer>().sprite;
            if (image.TryGetComponent<Image>(out Image sprite)) {
                sprite.sprite = texture;
                sprite.useSpriteMesh = true;
            }
            if (TryGetComponent<AspectRatioFitter>(out AspectRatioFitter fitter))
            {
                fitter.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
                fitter.aspectRatio = .6f;
            }
        }

        internal IPlayer[] GetPlayers()
        {
            throw new NotImplementedException();
        }

    }
}
