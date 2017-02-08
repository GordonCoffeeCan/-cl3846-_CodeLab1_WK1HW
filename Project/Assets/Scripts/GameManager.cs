using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private Text _scoreUI;
    public static int _score = 0;

    // Use this for initialization
    void Start () {
        _scoreUI = GameObject.Find("Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        _scoreUI.text = _score.ToString();

    }
}
