using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Rotation : MonoBehaviour
{
    public float rotationSpeed = 0.2f;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Moved)
            {
                float horizontalMove = touch.deltaPosition.x;
                transform.Rotate(0, -horizontalMove * rotationSpeed, 0);
            }
        }
    }
}
