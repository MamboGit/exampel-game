using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamerScript : MonoBehaviour {

    public Transform lookAt;

    private bool smooth = true;
    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0, 2.42f, -10f);

    private void LateUpdate()
    {
        Vector3 desiredPosition = lookAt.transform.position + offset;


        transform.position = desiredPosition;
    }


}
