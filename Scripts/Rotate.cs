using UnityEngine;

public class Rotate : MonoBehaviour {
    public float speed;

    private float angle = 0;

    private void Update() {
        angle += Time.deltaTime * speed;
        if (angle > 360) {
            angle -= 360;
        }

        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

}
