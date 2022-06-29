using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        throw new NotImplementedException();
    }

    internal void RemovePlayer(PlayerType aI)
    {
        throw new NotImplementedException();
    }
}
