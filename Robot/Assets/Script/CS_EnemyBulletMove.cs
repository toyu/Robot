using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_EnemyBulletMove : MonoBehaviour {

    private float speed = 120f, lifeTime = 5f;
    private float time = 0f;
    public Vector3 playerPosition;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        transform.LookAt(transform.TransformDirection(playerPosition));
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.forward * speed;

        time += Time.deltaTime;
        if (time > lifeTime) Destroy(this.gameObject);
    }
}
