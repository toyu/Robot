using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_OnClick : MonoBehaviour {
    public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnClick()
    {
        GameObject.Find("SceneManager").GetComponent<CS_SceneManager>().LoadScene(sceneName);
    }
}
