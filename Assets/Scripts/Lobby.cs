using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lobby : MonoBehaviour
{
    [Header("Player GUIs")]
    public TMP_InputField aiPlayerInputField;
    public TextMeshProUGUI hostingText;
    public GameObject localPlayersContainer;
    public GameObject onlinePlayersContainer;
    [Header("Proffession GUIs")]
    public GameObject professionButtonTemplate;
    public Transform professionButtonContainer;

    [Serializable]
    class ProfessionsWrapper : object
    {
        public Profession[] professions;
    }

    [Serializable]
    class Profession : object
    {
        [SerializeField]
        string name;
        [SerializeField]
        string resourcePath;

        public Sprite GetIcon()
        {
            GameObject sprite = (GameObject)Resources.Load(resourcePath);
            return sprite.GetComponent<SpriteRenderer>().sprite;
        }

        public string GetText(int index)
        {
            return name + "\n" + index + " or " + (12 - index);
        }
    }

    public void StartLobby(int moneyWinCondition)
    {
        StartLobby();
    }

    public void StartLobby(float timeWinCondition)
    {
        StartLobby();
    }

    private void StartLobby()
    {
        CreateJobButtons();
    }

    private void CreateJobButtons()
    {
        TextAsset professionsJson = (TextAsset)Resources.Load("Professions");
        ProfessionsWrapper professions = JsonUtility.FromJson<ProfessionsWrapper>(professionsJson.text);
        for (int i = 0; i < professions.professions.Length; i++)
        {
            GameObject button = GameObject.Instantiate(professionButtonTemplate);
            button.transform.SetParent(professionButtonContainer);
            button.GetComponentInChildren<Image>().sprite = professions.professions[i].GetIcon();
            button.GetComponentInChildren<TextMeshProUGUI>().text = professions.professions[i].GetText(i);
        }
    }

    public void ChooseProfession(int professionIndex)
    {

    }
}
