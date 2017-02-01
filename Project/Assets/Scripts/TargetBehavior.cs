using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBehavior : MonoBehaviour {
    private SpriteRenderer _target;
    private Text _scoreUI;
    private int _score = 0;

    private void Awake() {
        _target = this.GetComponent<SpriteRenderer>();
        _scoreUI = GameObject.Find("Text").GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D _col) {
        if(_col.gameObject.tag == "ball") {
            _target.color = Random.ColorHSV();

            _score++;
            _scoreUI.text = _score.ToString();
        }
    }
}
