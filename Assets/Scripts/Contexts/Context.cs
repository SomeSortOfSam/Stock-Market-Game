using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace StockMarketGame
{
    public class Context : MonoBehaviour
    {
        [Header("Game Manager Context")]
        public RectTransform tickerTapeTargetTransform;

        private UnityEvent<string> requestSceneChangeEvent = new UnityEvent<string>();

        public virtual void Start()
        {
            if (tickerTapeTargetTransform.TryGetComponent(out Image image))
            {
                image.enabled = false;
            }
        }

        public virtual void SubscribeToEvents(GameManager subscriber)
        {
            requestSceneChangeEvent.AddListener(subscriber.OnSceneChangeRequested);
        }

        public virtual void OnTickerTapeAnimationFinished(Game game) { }

        public void RequestSceneChange(string requestedSceneName)
        {
            requestSceneChangeEvent.Invoke(requestedSceneName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}