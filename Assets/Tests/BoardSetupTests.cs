using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using StockMarketGame;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardSetupTests
{
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
        Assert.AreEqual((12 * 4) - 8, board.squares.Length); //4 sides minus start squares and corners
    }

}