using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour {
    public TMP_InputField aiPlayerInputField;
    public TextMeshProUGUI hostingText;
    public GameObject localPlayersContainer;
    public GameObject onlinePlayersContainer;

    public void StartLobby(int moneyWinCondition) {
        StartLobby();
    }

    public void StartLobby(float timeWinCondition) {
        StartLobby();
    }

    private void StartLobby() {

    }

    public void ChooseProfession(int professionIndex){

    }
}
