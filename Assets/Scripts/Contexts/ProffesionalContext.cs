using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StockMarketGame
{
    public class ProffesionalContext : Context
    {
        const float PROFFESION_INDRODUCTION_FRAME_LENGTH = 48;

        [Header("Proffession GUIs")]
        [SerializeField]
        protected GameObject professionTemplate;
        [SerializeField]
        protected RectTransform professionContainer;

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
            base.OnTickerTapeAnimationFinished(game);
            InstatiateProfessions(game.board);
            StartCoroutine(IntroduceProffesionsCoruotine());
            if (game.players.Count >= 0)
            {
                PopulateProffesions(game.players);
            }
        }

        private void InstatiateProfessions(Board board)
        {
            TextAsset professionsJson = (TextAsset)Resources.Load("Professions");
            ProfessionsWrapper professions = JsonUtility.FromJson<ProfessionsWrapper>(professionsJson.text);
            for (int i = 0; i < professions.professions.Length; i++)
            {
                InstatiateProfession(board, professions, i);
            }
        }

        private void InstatiateProfession(Board board, ProfessionsWrapper professions, int index)
        {
            GameObject button = Instantiate(professionTemplate);
            button.transform.SetParent(professionContainer);
            button.GetComponentInChildren<Image>().sprite = professions.professions[index].GetIcon();
            button.GetComponentInChildren<TextMeshProUGUI>().text = professions.professions[index].GetText(index, professions.professions.Length, board);
        }

        private IEnumerator IntroduceProffesionsCoruotine()
        {
            for (float i = PROFFESION_INDRODUCTION_FRAME_LENGTH; i > 0; i--)
            {
                Vector2 min = professionContainer.anchorMin;
                min.x = i / PROFFESION_INDRODUCTION_FRAME_LENGTH;
                professionContainer.anchorMin = min;
                yield return null;
            }
            professionContainer.anchorMin = Vector2.zero;
        }

        private void PopulateProffesions(IEnumerable<IPlayer> players)
        {
            PlayerFactory.lastPlayerIndex = -1;
            foreach (IPlayer player in players)
            {
                ProffesionButton proffesionButton = professionContainer.GetChild(player.GetJobIndex()).GetComponent<ProffesionButton>();
                Type type = player.GetType();
                if (type == typeof(LocalPlayer))
                {
                    proffesionButton.AddPlayer(PlayerFactory.PlayerType.Hotseat);
                }
            }
        }
    }
}