using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_BulletMove : MonoBehaviour
{
    private float speed = 10f, lifeTime = 5f;
    private float time = 0f, distance;
    GameObject cursor, target;
    Vector3 startPos, cursorPos;

    // Use this for initialization
    void Start()
    {
        cursor = GameObject.Find("Cursor");
        target = GameObject.Find("unitychan").GetComponent<CS_PlayerController>().target;

        startPos = this.transform.position;
        cursorPos = cursor.GetComponent<CS_CursorMove>().rectTransform.position;

        if (target != null) distance = Vector3.Distance(startPos, target.transform.position);
        else distance = 2000f;

        transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, distance)));

        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame

    void Update()
    {
        transform.position += transform.forward * speed;

        time += Time.deltaTime;
        if (time > lifeTime) Destroy(this.gameObject);
    }
}
