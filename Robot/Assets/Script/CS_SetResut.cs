using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SetResutText : MonoBehaviour {
    private float playerTime;

	// Use this for initialization
	void Start () {
        playerTime = GameObject.Find("GameManager").GetComponent<CS_SaveValue>().GetTime();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
