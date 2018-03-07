using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_EnemyCounterText : MonoBehaviour {
    private GameObject gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "残り敵機\n" + gameManager.GetComponent<CS_GameManager>().enemyNum.ToString() + " 機";
    }
}
