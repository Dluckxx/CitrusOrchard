using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float moveSpeed = 0.5F;

    private Camera cam;
    private Transform trans;
    private float horizontal;
    private float vertcal;

    void Start() {
        cam = GetComponent<Camera>();
        trans = GetComponent<Transform>();
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertcal = Input.GetAxis("Vertical");
        wasdMove();
    }

    void wasdMove() {
        trans.Translate(new Vector3(horizontal * moveSpeed, vertcal * moveSpeed, 0F));
    }
}