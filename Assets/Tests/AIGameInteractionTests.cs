using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using StockMarketGame;
using UnityEngine;
using UnityEngine.TestTools;


public class AIGameInteractionTests
{
    [Test]
    public void AIGainsMoneyOnTurnFromJob()
    {
        Game game = new(1000);
        AIPlayer player0 = new(0);
        AIPlayer player1 = new(1);
        AIPlayer player2 = new(2);
        AIPlayer player3 = new(3);
        game.players.Add(player0);
        game.players.Add(player1);
        game.players.Add(player2);
        game.players.Add(player3);
        game.ExecuteNextTurn(new(1, 1));
        game.ExecuteNextTurn(new(2, 1));
        game.ExecuteNextTurn(new(3, 1));
        game.ExecuteNextTurn(new(4, 1));
        Assert.AreEqual(400, player0.GetMonataryValue());
        Assert.AreEqual(300, player1.GetMonataryValue());
        Assert.AreEqual(200, player2.GetMonataryValue());
        Assert.AreEqual(100, player3.GetMonataryValue());
    }

    [Test]
    public void AILeavesJobWhenAtMoneyCap()
    {
        Game game = new(10000);
        AIPlayer player0 = new(0);
        game.players.Add(player0);
        for (int i = 0; i < 4; i++)
        {
            game.ExecuteNextTurn(new(1, 1));
        }
        Assert.AreNotEqual(400*4, player0.GetMonataryValue());


    }
}

