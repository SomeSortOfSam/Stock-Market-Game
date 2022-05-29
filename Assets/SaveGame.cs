using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveGame
{
    [Serializable]
    public struct PlayerState {
        [Serializable]
        public enum Job { }

        public int cash;
        public Dictionary<string, int> stocks;
        public bool atWork;
        public Job job;
        public int boardPosition;
        public string name;
        public Color color;
    }

    public PlayerState[] players;
    public int stockIndex;
}
