using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    bool cameraFixed = false;

    void Update()
    {
        AdjustCamera();
    }
    void AdjustCamera()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cameraFixed = !cameraFixed;
        }
        if (cameraFixed==true) 
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
