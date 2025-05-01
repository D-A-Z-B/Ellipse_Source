using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private float time;
    [SerializeField] private float enterScale;
    [SerializeField] private float exitScale;

    public void OnPointerEnter(PointerEventData eventData) {
        transform.DOScale(enterScale, time);
    }

    public void OnPointerExit(PointerEventData eventData) {
        transform.DOScale(exitScale, time);
    }
}
