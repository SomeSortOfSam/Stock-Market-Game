using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningMenu : MonoBehaviour
{
    private GameObject currentMenu;

    public void Start()
    {
        currentMenu = transform.GetChild(0).gameObject;
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SwitchToMenu(GameObject newMenu)
    {
        currentMenu.SetActive(false);
        currentMenu = newMenu;
        currentMenu.SetActive(true);
    }

    public void Quit() { Application.Quit(); }
}
