using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform ball;
    public Transform ballSpawner;

    public static Vector2 arrowAngle = new Vector2(0, 0);
    public static bool haveBall = false;

    private Transform _arrow;
    private float rotateSpeed = 5;

    private void Awake() {
        _arrow = GameObject.Find("Arrow").transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate() {
        _arrow.Rotate(new Vector3(0, 0, Input.GetAxis("Vertical") * rotateSpeed));

        arrowAngle = new Vector2(0, _arrow.localEulerAngles.z);

        if (haveBall == false) {
            Transform _ball = (Transform)Instantiate(ball, ballSpawner.position, Quaternion.identity);
            haveBall = true;
        }
    }
}
