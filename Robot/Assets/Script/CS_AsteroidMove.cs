using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_AsteroidMove : MonoBehaviour {
    public GameObject explosion, dust;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Vector3 position, paticleAngle;
        GameObject sand, ex;

        if (other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "PlayerBullet")
        {
            paticleAngle = new Vector3(Random.Range(0f, 179f), Random.Range(0f, 179f), Random.Range(0f, 179f));
            ex = Instantiate(explosion, transform.position, Quaternion.Euler(paticleAngle)) as GameObject;
            ex.transform.localScale = transform.localScale * 3f;

            paticleAngle.x += 180f;
            paticleAngle.y += 180f;
            ex = Instantiate(explosion, transform.position, Quaternion.Euler(paticleAngle)) as GameObject;
            ex.transform.localScale = transform.localScale * 3f;

            paticleAngle = new Vector3(Random.Range(0, 359f), 0, 0);
            for (paticleAngle.y = Random.Range(0, 89f); paticleAngle.y < 359f; paticleAngle.y += 90f)
            {
                for (paticleAngle.z = Random.Range(0, 89f); paticleAngle.z < 359f; paticleAngle.z += 90f)
                {
                    sand = Instantiate(dust, transform.position, Quaternion.Euler(paticleAngle)) as GameObject;
                    sand.transform.localScale = transform.localScale * 3f;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
