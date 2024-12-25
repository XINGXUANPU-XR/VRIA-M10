using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotater : MonoBehaviour
{

    Gyroscope gyroscope;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;

            if(gyroscope != null)
            {
                gyroscope.enabled = true;
            }
            else
            {
                this.enabled = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Quaternion attitude = Quaternion.identity;

        attitude.SetFromToRotation(Vector3.down,
                                    Vector3.right * gyroscope.gravity.x
                                    + Vector3.up * gyroscope.gravity.y);

        transform.rotation = Quaternion.identity * attitude;
    }
}
