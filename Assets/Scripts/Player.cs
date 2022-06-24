using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void OnPreDiceRoll(GameManager game);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="game"></param>
    void OnDiceRoll(GameManager game, System.Tuple<int, int> roll);
    void OnPostDiceRoll(GameManager game);
    void SetRollingPlayer(GameManager game, bool isRoller);
    int GetSquareIndex();
}

public class LocalPlayer : IPlayer
{
    public int GetSquareIndex()
    {
        throw new NotImplementedException();
    }

    public void OnDiceRoll(GameManager game, Tuple<int, int> roll)
    {
        throw new NotImplementedException();
    }

    public void OnPostDiceRoll(GameManager game)
    {
        throw new System.NotImplementedException();
    }

    public void OnPreDiceRoll(GameManager game)
    {
        throw new System.NotImplementedException();
    }

    public void SetRollingPlayer(GameManager game, bool isRoller)
    {
        throw new System.NotImplementedException();
    }
}
