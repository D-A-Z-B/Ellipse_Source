using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestToggle : MonoBehaviour {
    public string currentQuestName;

    private Toggle toggle;
    private TextMeshProUGUI text;

    public void Init() {
        toggle = GetComponent<Toggle>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        gameObject.SetActive(false);
    }

    public void SetQuestName(string questName) {
        currentQuestName = questName;
        text.text = questName;
    }

    public void QuestComplete() {
        toggle.isOn = true;

        string temp = text.text;

        text.text = "<s>"+temp+"</s>";
    }
}