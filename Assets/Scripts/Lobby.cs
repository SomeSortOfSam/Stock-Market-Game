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
        public TextMeshProUGUI hostingText;
        public TMP_InputField localPlayerInputField;
        public TextMeshProUGUI onlinePlayersText;
        [Header("Proffession GUIs")]
        public GameObject professionButtonTemplate;
        public Transform professionButtonContainer;

        private IEnumerator<ProffesionButton> aiLoop;
        private int previousNumberOfAiPlayers = 0;

        private List<IPlayer> hotseatPlayers;
        private List<IPlayer> aiPlayers;

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
            ProffesionButton[] proffesionButtons = new ProffesionButton[professions.professions.Length];
            for (int i = 0; i < professions.professions.Length; i++)
            {
                GameObject button = Instantiate(professionButtonTemplate);
                button.transform.SetParent(professionButtonContainer);
                button.GetComponentInChildren<Image>().sprite = professions.professions[i].GetIcon();
                button.GetComponentInChildren<TextMeshProUGUI>().text = professions.professions[i].GetText(i, professions.professions.Length, board);
                proffesionButtons[i] = button.GetComponent<ProffesionButton>();
            }
            aiLoop = (IEnumerator<ProffesionButton>)proffesionButtons.GetEnumerator();
        }

        public void OnNumberOfAiPlayersChanged(string newNumber)
        {
            for (int i = 0; i < Mathf.Abs(int.Parse(newNumber) - previousNumberOfAiPlayers); i++)
            {
                if (!aiLoop.MoveNext())
                {
                    aiLoop.Reset();
                    aiLoop.MoveNext();
                }
                if (int.Parse(newNumber) > previousNumberOfAiPlayers)
                {
                    aiLoop.Current.AddPlayer(ProffesionButton.PlayerType.AI);
                }
                else
                {
                    aiLoop.Current.RemovePlayer(ProffesionButton.PlayerType.AI);
                }
            }
            previousNumberOfAiPlayers = int.Parse(newNumber);
        }
    }
}