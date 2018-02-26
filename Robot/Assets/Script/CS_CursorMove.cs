using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CursorMove : MonoBehaviour {
    public RectTransform rectTransform = null;
    public GameObject target = null;
    private float distance, lockDistance = 100f;
    private Vector3 neutralPosition, origin;

    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
        neutralPosition = rectTransform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            //カーソルの移動と制限
            if ((distance = Vector2.Distance(rectTransform.position, RectTransformUtility.WorldToScreenPoint(Camera.main, target.transform.position))) < lockDistance)
            {
                rectTransform.position += new Vector3(Input.GetAxis("Mouse X") * 10f, Input.GetAxis("Mouse Y") * 10f, 0f);
            }
            else
            {
                rectTransform.position += (Vector3)(RectTransformUtility.WorldToScreenPoint(Camera.main, target.transform.position) - (Vector2)rectTransform.position).normalized * (distance + 1f - lockDistance);
            }
        }
    }

    //カーソルをニュートラルに戻す
    public void setCursorNettral()
    {
        rectTransform.position = neutralPosition;
    }
}
