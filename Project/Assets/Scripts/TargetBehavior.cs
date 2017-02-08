using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBehavior : MonoBehaviour {
    private SpriteRenderer _target;

    private float _targetSpeed = 3;

    Vector3 _screenPosision;

    private void Awake() {
        _target = this.GetComponent<SpriteRenderer>();
        
        _screenPosision = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * _targetSpeed * Time.deltaTime);

        if (transform.position.x < -_screenPosision.x - transform.GetComponent<SpriteRenderer>().bounds.size.x) {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D _col) {
        if(_col.gameObject.tag == "ball") {
            Destroy(_col.gameObject);
            Destroy(gameObject);

            GameManager._score++;

            PlayerController.haveBall = false;
        }
    }
}
