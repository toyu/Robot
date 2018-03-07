using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CreateMap : MonoBehaviour {
    public GameObject[] asteroid = new GameObject[3];
    private GameObject ast;
    private float x, y, z;
    private Vector3 position, rotation;

	// Use this for initialization
	void Start () {
		for(x = -100; x < 100; x += 50)
        {
            for (y = -100; y < 100; y += 50)
            {
                for (z = -100; z < 100; z += 50)
                {
                    position = new Vector3(Random.Range(x - 20, x + 20), Random.Range(y - 20, y + 20), Random.Range(z - 20, z + 20));
                    rotation = new Vector3(Random.Range(0, 359f), Random.Range(0, 359f), Random.Range(0, 359f));
                    ast = Instantiate(asteroid[Random.Range(0, 3)], position, Quaternion.Euler(rotation)) as GameObject;
                    ast.transform.localScale *= Random.Range(1.5f, 4f);
                }
            }
        }

        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
