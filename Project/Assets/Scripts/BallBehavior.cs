using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {
    private bool isBallHit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space) && isBallHit == false) {
            isBallHit = true;
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(PlayerController.arrowAngle.y * Mathf.Deg2Rad), Mathf.Sin(PlayerController.arrowAngle.y * Mathf.Deg2Rad)) * 18, ForceMode2D.Impulse);
        }

        if(this.transform.position.y < -8 || this.transform.position.x > SetObjectPosition._screenSize.x + 10) {
            Destroy(this.gameObject);
            PlayerController.haveBall = false;
        }
    }
}
