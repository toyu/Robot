using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_Timer : MonoBehaviour {
    public static float MAX_TIME = 4f; // カウントダウンの開始値
    float timeCounter = MAX_TIME;

    // Use this for initialization
    void Start () {
        GetComponent<UnityEngine.UI.Text>().text = MAX_TIME.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if(timeCounter <= 1.0f && timeCounter >0.0f)
        {
            this.GetComponent<Text>().text = "作戦開始";
        }
        else if(timeCounter <= 0.0f)
        {
            GameObject.Find("CountUpTimer").GetComponent<CS_CountUpTimer>().start = true;
            GameObject.Find("GameManager").GetComponent<CS_GameManager>().CreateEnemy();
            Destroy(this.gameObject);
        }
        else
        {
            GetComponent<UnityEngine.UI.Text>().text = ((int)timeCounter).ToString();
        }

        timeCounter -= Time.deltaTime;
    }
}
