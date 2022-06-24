using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewGameMenu : Context
{
    public Toggle moneyToggle;
    public TMP_InputField moneyField;
    public Toggle timeToggle;
    public TMP_InputField timeField;

    public void ToggleMoneyVictory(bool value)
    {
        moneyField.interactable = value;
        if (moneyField.interactable)
        {
            moneyField.text = (moneyField.placeholder as TextMeshProUGUI).text;
        }
        if (timeToggle.isOn == value)
        {
            timeToggle.isOn = !value;
        }
    }

    public void ToggleTimeVictory(bool value)
    {
        timeField.interactable = value;
        if (timeField.interactable)
        {
            timeField.text = (timeField.placeholder as TextMeshProUGUI).text;
        }
        if (moneyToggle.isOn == value)
        {
            moneyToggle.isOn = !value;
        }
    }

    public void StartGame()
    {
        GameObject lobbyObject = transform.GetChild(transform.childCount - 1).gameObject;
        RequestSceneChange("NewGameLobby");
        Lobby lobby = lobbyObject.GetComponent<Lobby>();
        if (timeToggle.isOn)
        {
            lobby.StartLobby(float.Parse(timeField.text));
        }
        else
        {
            lobby.StartLobby(int.Parse(moneyField.text));
        }
    }
}
