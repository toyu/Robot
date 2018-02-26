using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices;

public class CS_PlayerController : MonoBehaviour {
    public float speed, rotateSpeed, lockonMaxDistance ,x ,y, z;
    public GameObject bullet;
    public GameObject target, cursor;
    public bool isTarget = false;

    // Use this for initialization
    void Start () {
        cursor = GameObject.Find("Cursor");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        //視点、照準移動////////////////////////////////////////////////////////////////////////////////////
        if (isTarget /*&& Input.GetAxis("Mouse Y") == 0f && Input.GetAxis("Mouse X") == 0f*/)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDir, rotateSpeed * Time.deltaTime, 0f));
        }
        else
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotateSpeed, Input.GetAxis("Mouse X") * rotateSpeed, 0));
        }

        //移動操作/////////////////////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.75f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 0.5f;
        }

        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(1, 0, 1).normalized * speed;
        }
        else if (Input.GetKey("w") && Input.GetKey("a"))
        {
            transform.position += transform.TransformDirection(-1, 0, 1).normalized * speed;
        }
        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(1, 0, -1).normalized * speed;
        }
        else if (Input.GetKey("s") && Input.GetKey("a"))
        {
            transform.position += transform.TransformDirection(-1, 0, -1).normalized * speed;
        }
        else if (Input.GetKey("w") && Input.GetKey("s"))
        {
            
        }
        else if (Input.GetKey("a") && Input.GetKey("d"))
        {
            
        }
        else if (Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(0, 0, 1).normalized * speed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position += transform.TransformDirection(0, 0, -1).normalized * speed;
        }
        else if (Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(1, 0, 0).normalized * speed;
        }
        else if (Input.GetKey("a"))
        {
            transform.position += transform.TransformDirection(-1, 0, 0).normalized * speed;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 0.5f, 0);
        }
        if (Input.GetKey("c"))
        {
            transform.position += new Vector3(0, -0.5f, 0);
        }

        //攻撃////////////////////////////////////////////////////////////////////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position + transform.TransformDirection(1f, 1f, 1f), transform.rotation);
        }

        //ロックオン////////////////////////////////////////////////////////////////////////////////////
        if (Input.GetMouseButtonDown(1))
        {
            if (isTarget)
            {
                isTarget = false;
                target = null;
                cursor.GetComponent<CS_CursorMove>().target = null;
                cursor.GetComponent<CS_CursorMove>().setCursorNettral();
            }
            else
            {
                target = GetTargetEnemy();
                if(target != null)
                {
                    isTarget = true;
                    cursor.GetComponent<CS_CursorMove>().target = target;
                }
            }
        }
    }

    // ロックオン対象の敵を取得////////////////////////////////////////////////////////////////////////////////////
    private GameObject GetTargetEnemy(bool isNearestPlayer = false, bool isScreenCentral = true)
    {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy")
            //.Where(enemy => enemy.GetComponent<CS_EnemyMove>().IsVisible() == true)                                                  // 画面内にいるか
            //.Where(enemy => Camera.main.WorldToScreenPoint(enemy.transform.position).z > -(mainCamera.transform.localPosition.z))  // カメラから見てプレイヤーより遠くにいるか
            .Where(enemy => Vector3.Distance(transform.position, enemy.transform.position) < lockonMaxDistance);                      // ロックオン可能範囲にいるか
            //.Where(enemy => RaycastEnemy(enemy) == true);                                                                            // 射線が通るか

        //プレイヤーに一番近い敵を取得
        if (isNearestPlayer)
        {
            enemys = enemys.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position));
        }

        // 画面中央に一番近い敵を取得
        if (isScreenCentral)
        {
            enemys = enemys.OrderBy(enemy => Vector2.Distance(new Vector2(Screen.width / 2.0f, Screen.height / 2.0f), Camera.main.WorldToScreenPoint(enemy.transform.position)));
        }

        return enemys.FirstOrDefault();
    }

    /*//指定した敵へと射線が通るかチェック
    private bool RaycastEnemy(GameObject enemy)
    {
        var heading = enemy.transform.position - mainCamera.transform.position;    // プレイヤーではなくカメラの位置を原点とする
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

        int layerMask = (1 << LayerMask.NameToLayer("Enemy")) + (1 << LayerMask.NameToLayer("Terrain")); // "Enemy"と"Terrain"レイヤー以外を無視
        var hits = Physics.RaycastAll(mainCamera.transform.position, direction, lockonMaxDistance, layerMask);

        foreach (var hit in hits.OrderBy(hit => hit.distance))
        {
            if (hit.collider.CompareTag("Terrain"))
            {
                // カメラがプレイヤーより下の場合は地形を無視する（めり込み対策）
                if (transform.position.y > mainCamera.transform.position.y)
                {
                    continue;
                }

                return false;
            }
            else if (hit.collider.CompareTag("Enemy") && hit.transform.position == enemy.transform.position)
            {
                return true;
            }
        }

        return false;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");
    }
}
