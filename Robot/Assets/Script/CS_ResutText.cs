using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_SetResut : MonoBehaviour {
    string result;
    private float playerTime;

	// Use this for initialization
	void Start () {
        playerTime = GameObject.Find("GameManager").GetComponent<CS_SaveValue>().GetTime();

        if (playerTime < 10f) result = "S";
        else if (playerTime < 15f) result = "A";
        else if (playerTime < 20f) result = "B";
        else if (playerTime < 25f) result = "C";
        else result = "D";

        GetComponent<UnityEngine.UI.Text>().text = ("作戦時間: " + (int)playerTime + "秒\n評価: " + result).ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
