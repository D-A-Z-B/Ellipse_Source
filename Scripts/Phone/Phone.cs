using UnityEngine;
using DG.Tweening;
using TMPro;

public class Phone : MonoBehaviour {
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _timeText;

    [SerializeField] private float openTime, closeTime;
    public PhoneUI phoneUI;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public bool IsOpen { get; private set; } = false;
    public bool Lock { get; set; } = false;

    private void Awake() {
        phoneUI = GetComponent<PhoneUI>();
    }

    private void Start() {
        // 초기 위치와 회전을 저장해 두고, 부모 위치 변화에 대한 보정 사용
        initialPosition = new Vector3(1300, -1200, 3);
        initialRotation = Quaternion.Euler(new Vector3(0, 0, 90));

        // 시작 위치와 회전 설정
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;

        _player.Input.PhoneEvent += ActivePhone;
    }

    private void OnDestroy() {
        _player.Input.PhoneEvent -= ActivePhone;
    }

    private void ActivePhone(bool flag) {
        if(Lock) return;

        if(flag) Open();
        else Close();
    }

//     private void Update() {
//         if (Keyboard.current.tabKey.wasPressedThisFrame) {
//             Open();
//         }
//         else if (Keyboard.current.tabKey.wasReleasedThisFrame) {
//             Close();
//         }

// /*         if (Keyboard.current.tKey.wasPressedThisFrame) {
//             //phoneUI.QuestComplete("Test");
//             phoneUI.QuestRefresh();
//         } */
//     }

    public void Open() {
        transform.DOLocalMove(new Vector3(0, -200, 1), openTime);
        transform.DOLocalRotate(Vector3.zero, openTime).OnComplete(() => IsOpen = true);
    }

    public void Close() {
        // 부모 오브젝트 기준 위치로 돌아가도록 설정
        IsOpen = false;
        transform.DOLocalMove(initialPosition, closeTime);
        transform.DOLocalRotate(initialRotation.eulerAngles, closeTime);
    }
}
