using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SaveValue : MonoBehaviour {
    public static float playerTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTime(float time)
    {
        playerTime = time;
    }

    public float GetTime()
    {
        return playerTime;
    }
}
