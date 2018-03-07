using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_CountUpTimer : MonoBehaviour {
    public static float MAX_TIME = 30f; // カウントダウンの開始値
    public float timeCounter = MAX_TIME;
    public bool start = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (start == true)
        {
            GetComponent<UnityEngine.UI.Text>().text = ((int)timeCounter).ToString();
            timeCounter += Time.deltaTime;
        }
    }
}