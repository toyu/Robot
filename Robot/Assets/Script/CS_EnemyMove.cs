using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_EnemyMove : MonoBehaviour
{
    private bool visible;
    public float rotateSpeed = 3f, moveRange = 100f;
    private float playerDistance, time = 0f, fireTime, bulletSpeed = 120f;
    Vector3 movePoint, currentPoint, speed, playerSpeedCurrent, playerSpeedBefore, playerSpeedAfter;
    public GameObject bullet, explosion;
    private GameObject player, cursor, gameManager;

    private void Awake()
    {
        player = GameObject.Find("unitychan");
        cursor = GameObject.Find("Cursor");
        gameManager = GameObject.Find("GameManager");
    }

    // Use this for initialization
    void Start()
    {
        playerSpeedBefore = player.transform.position;
        movePoint = new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
        fireTime = Random.Range(0.75f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDir, rotateSpeed * Time.deltaTime, 0f));

        transform.position = Vector3.Lerp(transform.position, movePoint, Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint) < 10f)
        {
            movePoint = new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
        }

        //Debug.Log(movePoint);
        //Debug.Log(transform.position);

        //if(transform.position.x < -60f || transform.position.x > 60f) x *= -1;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        //敵の偏差射撃
        playerSpeedCurrent = player.transform.position - playerSpeedBefore;
        playerSpeedBefore = player.transform.position;
        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        playerSpeedAfter = player.transform.position + playerSpeedCurrent * playerDistance / bulletSpeed / Time.deltaTime;

        if (time > fireTime)
        {
            GameObject recentBullet = Instantiate(bullet, this.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
            recentBullet.GetComponent<CS_EnemyBulletMove>().playerPosition = playerSpeedAfter;
            fireTime = Random.Range(0.75f, 1.5f);
            //recentBullet.GetComponent<Rigidbody>().AddForce(recentBullet.transform.forward * bulletSpeed, ForceMode.Impulse);

            time = 0f;
        }
    }

    //弾が当たったら
    private void OnTriggerEnter(Collider other)
    {
        Vector3 paticleAngle;

        if(other.gameObject.tag == "PlayerBullet")
        {
            if (this.gameObject == player.GetComponent<CS_PlayerController>().target)
            {
                player.GetComponent<CS_PlayerController>().isTarget = false;
                player.GetComponent<CS_PlayerController>().target = null;
                cursor.GetComponent<CS_CursorMove>().setCursorNettral();
            }

            paticleAngle = new Vector3(0, Random.Range(0f, 179f), Random.Range(0f, 179f));
            Instantiate(explosion, transform.position, Quaternion.Euler(paticleAngle));

            paticleAngle.y += 180f;
            paticleAngle.z += 180f;
            Instantiate(explosion, transform.position, Quaternion.Euler(paticleAngle));

            gameManager.GetComponent<CS_GameManager>().enemyNum--;
            Destroy(this.gameObject);
        }
    }

    //カメラに写ったら
    private void OnWillRenderObject()
    {
        this.visible = true;
    }

    public bool IsVisible()
    {
        return this.visible;
    }

    private void move()
    {

    }
}
