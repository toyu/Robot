using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_HPText : MonoBehaviour {
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "HP " + player.GetComponent<CS_PlayerController>().hp.ToString();
    }
}
