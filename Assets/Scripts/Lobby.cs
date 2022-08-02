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
        [Header("Proffession GUIs")]
        [SerializeField]
        private GameObject professionButtonTemplate;
        [SerializeField]
        private RectTransform professionButtonContainer;
        [Space]
        [SerializeField]
        private TextMeshProUGUI hostingText;
        [SerializeField]
        private RectTransform hostingOptionsContainer;
        public bool onHostMachine = true;

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

        public override void Start()
        {
            base.Start();
            hostingOptionsContainer.gameObject.SetActive(false);
        }

        public override void OnTickerTapeAnimationFinished(Game game)
        {
            CreateJobButtons(game.board);
            StartCoroutine(IntroduceProffesionsCoruotine());
            if (onHostMachine)
            {
                StartCoroutine(ShowHostControlsCoruotine());
            }
        }

        private IEnumerator ShowHostControlsCoruotine()
        {
            hostingOptionsContainer.gameObject.SetActive(true);
            hostingOptionsContainer.offsetMax = Vector2.zero;
            for (float i = 0; i < 48; i++)
            {
                Vector2 max = hostingOptionsContainer.offsetMax;
                max.y = (i / 48f) * 100;
                hostingOptionsContainer.offsetMax = max;
                yield return null;
            }
            hostingOptionsContainer.offsetMax = new Vector2(0, 100);
        }

        private IEnumerator IntroduceProffesionsCoruotine()
        {
            for (float i = 48; i > 0; i--)
            {
                Vector2 min = professionButtonContainer.anchorMin;
                min.x = i / 48f;
                professionButtonContainer.anchorMin = min;
                yield return null;
            }
            professionButtonContainer.anchorMin = Vector2.zero;
        }

        private void CreateJobButtons(Board board)
        {
            TextAsset professionsJson = (TextAsset)Resources.Load("Professions");
            ProfessionsWrapper professions = JsonUtility.FromJson<ProfessionsWrapper>(professionsJson.text);
            for (int i = 0; i < professions.professions.Length; i++)
            {
                CreateJobButton(board, professions, i);
            }
        }

        private void CreateJobButton(Board board, ProfessionsWrapper professions, int index)
        {
            GameObject button = Instantiate(professionButtonTemplate);
            button.transform.SetParent(professionButtonContainer);
            button.GetComponentInChildren<Image>().sprite = professions.professions[index].GetIcon();
            button.GetComponentInChildren<TextMeshProUGUI>().text = professions.professions[index].GetText(index, professions.professions.Length, board);
        }

        public void OnAIAdded()
        {
            int randi = UnityEngine.Random.Range(0, professionButtonContainer.childCount);
            professionButtonContainer.GetChild(randi).GetComponent<ProffesionButton>().AddPlayer(ProffesionButton.PlayerType.AI);
        }

        public void OnStartGame()
        {
            throw new NotImplementedException();
        }

    }
}