using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ParticleDestroy : MonoBehaviour {
    public float destroyTime;
    private float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > destroyTime) Destroy(this.gameObject);
	}
}
