using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace StockMarketGame
{
    public class Lobby : Context
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
            [SerializeField]
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

            public string GetText(int index, int maxIndex, Board board)
            {
                string output = name + "\n";
                output += (index + 2) + " or " + (12 - index) + "\n";
                output += "$" + (board.jobMultipler * ((maxIndex - index)));
                return output;
            }
        }

        public override void OnTickerTapeAnimationFinished(Game game)
        {
            CreateJobButtons(game.board);
        }

        private void CreateJobButtons(Board board)
        {
            TextAsset professionsJson = (TextAsset)Resources.Load("Professions");
            ProfessionsWrapper professions = JsonUtility.FromJson<ProfessionsWrapper>(professionsJson.text);
            for (int i = 0; i < professions.professions.Length; i++)
            {
                GameObject button = Instantiate(professionButtonTemplate);
                button.transform.SetParent(professionButtonContainer);
                button.GetComponentInChildren<Image>().sprite = professions.professions[i].GetIcon();
                button.GetComponentInChildren<TextMeshProUGUI>().text = professions.professions[i].GetText(i, professions.professions.Length, board);
            }
        }
    }
}