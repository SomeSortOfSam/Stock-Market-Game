using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class StockTests
{
    [Test]
    public void TestPolarity()
    {
        Stock stockA = new("Stock A", 5, 5, false);
        Stock stockB = new("Stock B", 5, 5, true);

        Assert.Greater(stockB.GetCurrentPrice(1, 4), stockA.GetCurrentPrice(1, 4));
    }

    [Test]
    public void TestMarketIndexOutOfBounts()
    {
        Game game = new();
        game.marketIndex = 29;
        Assert.AreEqual(29, game.marketIndex, 0, "Indexes at the end of the tape are valid");
        game.marketIndex = 30;
        Assert.AreEqual(28, game.marketIndex, 0, "Indexes over end of the tape bounce");
        game.marketIndex = 0;
        Assert.AreEqual(0, game.marketIndex, 0, "Indexes at the end of the tape are valid");
        game.marketIndex = -1;
        Assert.AreEqual(1, game.marketIndex, 0, "Indexes over end of the tape bounce");
        game.marketIndex = -29;
        Assert.AreEqual(29, game.marketIndex, 0, "Indexes well over end of the tape bounce");
        game.marketIndex = -30;
        Assert.AreEqual(28, game.marketIndex, 0, "Indexes far over end of the tape bounce twice");
    }
}
