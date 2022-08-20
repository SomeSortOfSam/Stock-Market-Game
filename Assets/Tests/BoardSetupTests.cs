using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using StockMarketGame;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardSetupTests
{
    private const int expectedBoardSize = (12 * 4);
    Board board;

    [OneTimeSetUp]
    public void WellBefore()
    {
        TextAsset boardJson = (TextAsset)Resources.Load("Board");
        board = JsonUtility.FromJson<Board>(boardJson.text);
    }

    [Test]
    public void BoardHasValidNumberOfSquares()
    {
        Assert.AreEqual(expectedBoardSize - 8, board.squares.Length); //Board.json does not include start squares and corners
    }

    [Test]
    public void BoardHasExpectedFeeSquares()
    {
        for (float i = 0; i < expectedBoardSize; i += 6f)
        {
            Assert.IsInstanceOf<Board.FeeSquare>(board.IndexToSquare(Mathf.CeilToInt(i)), "At " + Mathf.CeilToInt(i));
        }
    }

    [Test]
    public void BoardHasExpectedStockholderSquares()
    {
        for (int i = 3; i < expectedBoardSize; i += 6)
        {
            Assert.IsInstanceOf<Board.StockholderSquare>(board.IndexToSquare(i), "At " + i);
        }
    }

    [Test]
    public void CornerSquaresExitRight()
    {
        for (int i = 6; i < expectedBoardSize; i += 12)
        {
            Board.CornerSquare corner = (Board.CornerSquare)board.IndexToSquare(i);
            Player player = new AIPlayer(0);
            player.squareIndex = i;
            Assert.Less(i, corner.RollToIndex(player, 2));
        }
    }

    [Test]
    public void StartSquaresExitLeftOnEvenRightOnOdd()
    {
        for (int i = 12; i < expectedBoardSize; i += 12)
        {
            Board.StartSquare corner = (Board.StartSquare)board.IndexToSquare(i);
            Player player = new AIPlayer(0);
            player.squareIndex = i;
            Assert.Greater(i, corner.RollToIndex(player, 2));
            Assert.Less(i, corner.RollToIndex(player, 3));
        }
    }

}