using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const int TICKER_TAPE_ANIMATION_FRAME_LEGTH = 24;

    [SerializeField]
    private RectTransform tikerTape;

    private Context currentContext;

    private Coroutine tickerTapeAnimation;
    public UnityEvent tikerTapeAnimationFinishedEvent;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        GameObject game = Instantiate(Resources.Load("Bootstrap")) as GameObject;
        if (game == null)
        {
            throw new ApplicationException("Boostrap could not be loaded");
        }

        DontDestroyOnLoad(game);
    }

    private void Start()
    {
        OnNewScene();
    }

    public void SwitchToScene(int buildIndex)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(buildIndex);
        loadScene.completed += (a) => { OnNewScene(); };
    }

    public void SwitchToScene(string sceneName)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneName);
        loadScene.completed += (a) => { OnNewScene(); };
    }

    private void OnNewScene()
    {
        StopAllCoroutines();
        Context newContext = FindObjectOfType<Context>();
        if (newContext == null)
        {
            throw new ArgumentException("Destination scene did not have context");
        }
        currentContext = newContext;
        newContext.requestSceneChangeEvent.AddListener(SwitchToScene);
        tickerTapeAnimation = StartCoroutine(TickerTapeAnimationCorutine());
    }

    private IEnumerator TickerTapeAnimationCorutine()
    {
        if (currentContext.tickerTapeTargetTransform != null)
        {
            for (int i = 0; i < TICKER_TAPE_ANIMATION_FRAME_LEGTH; i++)
            {
                LerpRectTransform(tikerTape, currentContext.tickerTapeTargetTransform, ((float)i) / TICKER_TAPE_ANIMATION_FRAME_LEGTH);
                yield return null;
            }
        }
        tikerTapeAnimationFinishedEvent.Invoke();
    }

    private static void LerpRectTransform(RectTransform changer, RectTransform target, float percent)
    {
        changer.anchorMax = Vector2.Lerp(changer.anchorMax, target.anchorMax, percent);
        changer.anchorMin = Vector2.Lerp(changer.anchorMin, target.anchorMin, percent);
        changer.offsetMax = Vector2.Lerp(changer.offsetMax, target.offsetMax, percent);
        changer.offsetMin = Vector2.Lerp(changer.offsetMin, target.offsetMin, percent);
        changer.pivot = Vector2.Lerp(changer.pivot, target.pivot, percent);
        changer.rotation = Quaternion.Lerp(changer.rotation, target.rotation, percent);

    }
}

public class Game
{
    private const int maximumMarketIndex = 29;

    public int marketIndex
    {
        set => _marketIndex = ClampMarketIndex(value);
        get => _marketIndex;
    }

    private int _marketIndex;

    public class Square
    {
        public bool forward;
        public int stockChange;
        public Stock stock;
        public bool forcedSell;
        /// <summary>
        /// Is this none stock on the the coner or the edge?
        /// </summary>
        public bool brokerFee;
    }

    private IPlayer[] players;

    private int ClampMarketIndex(int value)
    {
        if (value > maximumMarketIndex)
        {
            return ClampMarketIndex(maximumMarketIndex - (value - maximumMarketIndex));
        }
        else if (value < 0)
        {
            return ClampMarketIndex(-value);
        }
        return value;
    }

    public Game(int moneyWinCondition, IPlayer[] players)
    {
        this.players = players;
    }

    public Game(float timeWinCondition, IPlayer[] players)
    {
        this.players = players;
    }

    private Tuple<int, int> RollDice()
    {
        throw new NotImplementedException();
    }

    public int StockToCurrentPrice(Stock stock)
    {
        throw new NotImplementedException();
    }

    public int StockToMinimumPrice(Stock stock)
    {
        throw new NotImplementedException();
    }
}


