using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;

public struct GameTime {
    public int hour;
    public int minute;

    public GameTime(int hour, int minute) {
        this.hour = hour;
        this.minute = minute;
    }
}

[System.Serializable]
public struct QuestData {
    public string questName;
    public bool isComplete;

    public QuestData(string questName, bool isComplete) {
        this.questName = questName;
        this.isComplete = isComplete;
    }

    public void Complete() {
        isComplete = true;
    }
}

public class PhoneUI : MonoBehaviour {
    [SerializeField] private GameObject Content;
    private List<QuestToggle> questList = new List<QuestToggle>();
    private List<QuestData> questDatas = new List<QuestData>();

    private TextMeshProUGUI timeText;
    private TextMeshProUGUI dayText;
    private GameTime currentTime;

    private void Awake() {
        questList = Content.transform.Find("Quest").GetComponentsInChildren<QuestToggle>().ToList();
        timeText = Content.transform.Find("Time").GetComponent<TextMeshProUGUI>();
        //dayText = Content.transform.Find("Day").GetComponent<TextMeshProUGUI>();

        questList.ForEach(x => x.Init());

        StartCoroutine(TimeRoutine());
    }

    private void Update() {

    }

    public void QuestRefresh() {
        questList.ForEach(x => x.gameObject.SetActive(false));

        for (int i = 0; i < questDatas.Count; ++i) {
            questList[i].SetQuestName(questDatas[i].questName);
            questList[i].gameObject.SetActive(true);
        }
    }

    public void AddQuest(string questName) {
        QuestData data = new QuestData(questName, false);
        questDatas.Add(data);
        QuestRefresh();
    }

    public void QuestComplete(string questName) {
        foreach (QuestToggle toggle in questList) {
            if (toggle.currentQuestName == questName) {
                toggle.QuestComplete();
            }
        }

        foreach (QuestData data in questDatas) {
            if (data.questName == questName) {
                data.Complete();
            }
        }
        QuestRefresh();
    }

    public bool IsCompleteQuest(string questName) {
        foreach (QuestData data in questDatas) {
            if (data.questName == questName) {
                return data.isComplete;
            }
        }
        return false;
    }

    public void DeleteAllQuest() {
        questDatas.Clear();
        QuestRefresh();
    }

    public void SetTime(GameTime time) {
        currentTime = time;
    }

    private IEnumerator TimeRoutine() {
        while (true) {
            bool blink = Mathf.FloorToInt(Time.time * 2) % 2 == 0;
            string timeString = blink ? $"{currentTime.hour:D2}:{currentTime.minute:D2}" : $"{currentTime.hour:D2} {currentTime.minute:D2}";
            timeText.text = timeString;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
