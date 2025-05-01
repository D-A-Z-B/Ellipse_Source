using TMPro;
using UnityEngine;
using DG.Tweening;

public class DialogManager : MonoBehaviour {
    public static DialogManager Instance = null;
    
    [SerializeField] private TextMeshProUGUI DialogBox;
    private CanvasGroup canvasGroup;

    private void Awake() {
        Instance = this;

        canvasGroup = DialogBox.GetComponentInParent<CanvasGroup>();
    }

    public void ShowDialog(float fadeInTime, string text) {
        DialogBox.text = text;
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1, fadeInTime);
    }

    public void HideDialog(float fadeOutTime) {
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, fadeOutTime);
    }
}
