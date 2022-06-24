using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Context : MonoBehaviour
{
    public RectTransform tickerTapeTargetTransform;

    public UnityEvent<string> requestSceneChangeEvent;

    public void Start()
    {
        if (tickerTapeTargetTransform.TryGetComponent(out Image image))
        {
            image.enabled = false;
        }
    }

    public void RequestSceneChange(string requestedSceneName)
    {
        requestSceneChangeEvent.Invoke(requestedSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
