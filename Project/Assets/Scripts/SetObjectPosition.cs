using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectPosition : MonoBehaviour {
    private float speed = 0.1f;

    private Transform _target;
    private Transform _ballSpawner;
    private Transform _ground;
    private Transform _arrow;
    public static Vector2 _screenSize;

    private void Awake() {
        _target = GameObject.Find("Target").transform;
        _ground = GameObject.Find("Ground").transform;
        _ballSpawner = GameObject.Find("BallSpawner").transform;
        _arrow = GameObject.Find("Arrow").transform;
    }

    // Use this for initialization
    void Start () {
        Resize();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void Resize() {
        Vector3 _screenPosision = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _screenSize = _screenPosision;

        _target.position = new Vector3(_screenPosision.x - _target.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
        _ground.position = new Vector3(-_screenPosision.x + _ground.GetComponent<SpriteRenderer>().bounds.size.x, -_screenPosision.y + _ground.GetComponent<SpriteRenderer>().bounds.size.y, 0);
        _ballSpawner.position = new Vector3(-_screenPosision.x + 1.18f, -_screenPosision.y + 1.05f, 0);
        _arrow.position = new Vector3(-_screenPosision.x + 1.18f, -_screenPosision.y + 1.05f, 0);
    }

    private void FixedUpdate() {
        _target.Translate(Vector3.up * speed);

        if(_target.position.y < -_screenSize.y || _target.position.y > _screenSize.y) {
            speed *= -1;
        }
    }
}
