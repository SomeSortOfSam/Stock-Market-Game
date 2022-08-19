using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StockMarketGame
{
    public class BoardVeiw : Context
    {
        public override void OnTickerTapeAnimationFinished(Game game)
        {
            base.OnTickerTapeAnimationFinished(game);
            for (int i = 0; i < 48; i++)
            {
                GameObject gameObject = new GameObject("Tile " + i, typeof(TextMeshProUGUI), typeof(Image));
                Image image = gameObject.GetComponent<Image>();
                Board.Square square = game.board.IndexToSquare(i);
                switch (square)
                {
                    case Board.StartSquare:
                        image.color = Color.white;
                        break;
                    case Board.CornerSquare:
                        image.color = Color.red;
                        break;
                    case Board.StockholderSquare:
                        image.color = Color.blue;
                        break;
                    case Board.NamedSquare n:
                        image.color = Color.green;
                        gameObject.GetComponent<TextMeshProUGUI>().text = n.directionIsRight ? "-->" : "<--";
                        break;
                }

            }
        }
    }
}