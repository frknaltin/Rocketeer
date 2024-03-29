using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    bool cameraFixed = false;
    public Transform target;
    public Vector3 offset;
    void Update()
    {
        AdjustCamera();
    }
    private void LateUpdate() 
    {
        transform.position = target.position + offset;
    }
    void AdjustCamera()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cameraFixed = !cameraFixed;
        }
        else if (cameraFixed==true) 
        {
            GetComponent<CameraFollow>().enabled=false;
            transform.SetPositionAndRotation(new Vector3(0,13,-34), Quaternion.Euler(new Vector3(0,0,0)));
        }
        else if (cameraFixed==false) 
        {
            GetComponent<CameraFollow>().enabled=true;
        }
    }
}
