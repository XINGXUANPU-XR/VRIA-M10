using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Zoom : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // 控制旋转速度
    public float zoomSpeed = 0.01f; // 控制缩放速度
    void Update()
    {
        // 检查是否有触摸输入
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                // 处理旋转
                if (touch.phase == TouchPhase.Moved)
                {
                    float horizontalMove = touch.deltaPosition.x;
                    transform.Rotate(0, -horizontalMove * rotationSpeed, 0);
                }
            }
            else if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);
                // 计算前一帧两指之间的距离和当前帧两指之间的距离
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
                // 计算距离差
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag; 
                // 处理缩放
                if (Mathf.Abs(deltaMagnitudeDiff) > 0.01f) // 设置一个阈值来避免小的抖动
                {
                    // 缩放模型
                    float scaleChange = deltaMagnitudeDiff * zoomSpeed;
                    Vector3 newScale = transform.localScale + Vector3.one * scaleChange;
                    newScale = Vector3.Max(newScale, Vector3.one * 0.1f); // 防止缩得过小
                    transform.localScale = newScale;
                }
            }
        }
    }
}
