using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lobby : MonoBehaviour {
    [Header("Player GUIs")]
    public TMP_InputField aiPlayerInputField;
    public TextMeshProUGUI hostingText;
    public GameObject localPlayersContainer;
    public GameObject onlinePlayersContainer;
    [Header("Proffession GUIs")]
    public GameObject professionButtonTemplate;
    public Transform professionButtonContainer;

    [Serializable]
    class ProfessionsWrapper : object , IEnumerable {

        public IEnumerator GetEnumerator() {
            return professions.GetEnumerator();
        }

        public ProfessionsWrapper(Profession[] professions) {
            this.professions = professions;
        }

        public Profession[] professions;
    }

    [Serializable]
    class Profession : object {

        public Profession(string name, string resourcePath, int professionIndex) {
            this.name = name;
            this.resourcePath = resourcePath;
            this.professionIndex = professionIndex;
        }

        [SerializeField]
        string name;
        [SerializeField]
        string resourcePath;
        [SerializeField]
        int professionIndex;

        public Sprite GetIcon() {
            return (Sprite) Resources.Load(resourcePath);
        }

        public string GetText(){
            return name + "\n" + professionIndex + " or " + (12 - professionIndex);
        }
    }

    public void StartLobby(int moneyWinCondition) {
        StartLobby();
    }

    public void StartLobby(float timeWinCondition) {
        StartLobby();
    }

    private void StartLobby() {
        ProfessionsWrapper professions = new ProfessionsWrapper(new Profession[]{new Profession("Bees", "Bee", 0),new Profession("Trees", "Tree", 1)});
        StreamWriter writer = new StreamWriter("Assets/Resources/test.png");
        writer.Write(JsonUtility.ToJson(professions,true));
        writer.Close();

        TextAsset professionsJson = (TextAsset) Resources.Load("Proffesions");
        professions = JsonUtility.FromJson<ProfessionsWrapper>(professionsJson.text);
        foreach (Profession profession in professions){
            GameObject button = GameObject.Instantiate(professionButtonTemplate);
            button.transform.SetParent(professionButtonContainer);
            button.GetComponentInChildren<Image>().sprite = profession.GetIcon();
            button.GetComponentInChildren<TextMeshProUGUI>().text = profession.GetText();
        }
    }

    public void ChooseProfession(int professionIndex) {

    }
}
