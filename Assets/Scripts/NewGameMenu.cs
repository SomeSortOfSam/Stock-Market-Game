using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace StockMarketGame
{
    public class NewGameMenu : Context
    {
        public Toggle moneyToggle;
        public TMP_InputField moneyField;
        public Toggle timeToggle;
        public TMP_InputField timeField;

        private UnityEvent<int> requestNewGameWithMoneyConditionEvent = new UnityEvent<int>();
        private UnityEvent<float> requestNewGameWithTimeConditionEvent = new UnityEvent<float>();

        public void ToggleMoneyVictory(bool value)
        {
            moneyField.interactable = value;
            moneyField.text = moneyField.interactable ? (moneyField.placeholder as TextMeshProUGUI).text : "";
            if (timeToggle.isOn == value)
            {
                timeToggle.isOn = !value;
            }
        }

        public void ToggleTimeVictory(bool value)
        {
            timeField.interactable = value;
            timeField.text = timeField.interactable ? (timeField.placeholder as TextMeshProUGUI).text : "";
            if (moneyToggle.isOn == value)
            {
                moneyToggle.isOn = !value;
            }
        }

        public void StartGame()
        {
            if (moneyToggle.isOn)
            {
                requestNewGameWithMoneyConditionEvent.Invoke(int.Parse(moneyField.text));
            }
            else
            {
                requestNewGameWithTimeConditionEvent.Invoke(float.Parse(timeField.text));
            }
            RequestSceneChange("NewGameLobby");
        }

        public override void SubscribeToEvents(GameManager subscriber)
        {
            requestNewGameWithMoneyConditionEvent.AddListener(subscriber.OnNewGameWithMoneyConditionRequested);
            requestNewGameWithTimeConditionEvent.AddListener(subscriber.OnNewGameWithTimeConditionRequested);
            base.SubscribeToEvents(subscriber);
        }
    }
}