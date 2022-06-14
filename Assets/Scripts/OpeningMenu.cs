using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpeningMenu : MonoBehaviour {
    private GameObject currentMenu;
    public Toggle moneyToggle;
    public TMP_InputField moneyField;
    public Toggle timeToggle;
    public TMP_InputField timeField;

    /// <summary>
    /// Unity method. Turns off all menus but the top level one when the canvas is loaded in. May need to be removed when animations are added
    /// </summary>
    public void Start() {
        currentMenu = transform.GetChild(1).gameObject;
        for (int i = 2; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SwitchToMenu(GameObject newMenu) {
        currentMenu.SetActive(false);
        currentMenu = newMenu;
        currentMenu.SetActive(true);
    }

    public void ToggleMoneyVictory(bool value) {
        moneyField.interactable = value;
        if (timeToggle.isOn == value)
        {
            timeToggle.isOn = !value;
        }
    }

    public void ToggleTimeVictory(bool value) {
        timeField.interactable = value;
        if (moneyToggle.isOn == value)
        {
            moneyToggle.isOn = !value;
        }
    }

    public static void Quit() {
        Application.Quit();
    }

    public void StartGame() {
        GameObject lobbyObject = transform.GetChild(transform.childCount - 1).gameObject;
        SwitchToMenu(lobbyObject);
        Lobby lobby = lobbyObject.GetComponent<Lobby>();
        if (timeToggle.isOn) {
            lobby.StartLobby(float.Parse(timeField.text));
        } else {
            lobby.StartLobby(int.Parse(moneyField.text));
        }
    }
}
