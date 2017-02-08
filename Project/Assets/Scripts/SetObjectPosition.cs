using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectPosition : MonoBehaviour {
    private float speed = 0.1f;

    public Transform target;
    private Transform _ballSpawner;
    private Transform _arrow;
    public static Vector2 _screenSize;

    private float spawnTime = 0.8f;

    private void Awake() {
        _ballSpawner = GameObject.Find("BallSpawner").transform;
        _arrow = GameObject.Find("Arrow").transform;
    }

    // Use this for initialization
    void Start () {
        Resize();
	}
	
	// Update is called once per frame
	void Update () {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0) {
            spawnTime = 0.8f;
            SpawnTarget();
        }
    }

    private void Resize() {
        Vector3 _screenPosision = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _screenSize = _screenPosision;

        _ballSpawner.position = new Vector3(-_screenPosision.x + 1.18f, -_screenPosision.y + 1.05f, 0);
        _arrow.position = new Vector3(-_screenPosision.x + 1.18f, -_screenPosision.y + 1.05f, 0);
    }

    private void FixedUpdate() {
        
    }

    private void SpawnTarget() {
        Instantiate(target, new Vector3(_screenSize.x + target.GetComponent<SpriteRenderer>().bounds.size.x, Random.Range(_screenSize.y - target.GetComponent<SpriteRenderer>().bounds.size.y, target.GetComponent<SpriteRenderer>().bounds.size.y - _screenSize.y), 0), Quaternion.identity);
    }
}
