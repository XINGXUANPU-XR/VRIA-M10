using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //回転速度の感度、60が良い
    public float pitchAngularSpeed, rollAngularSpeed, yawAngularSpeed;

    //現在算出されている1秒当たりの回転速度
    private float deltaRoll, deltaPitch, deltaYaw;

    //v.x = cd.x , v.y = cd.yに方法を設定
    public void DeltaAngles(Vector2 moveValue)
    {
        deltaRoll = moveValue.x;
        deltaPitch = moveValue.y;
    }

    //v.x = cd.x , v.y = cd.zに方法を設定
    public void DeltaAngleYaw(Vector2 moveValue)
    {
        deltaYaw = moveValue.x;
    }

    public void Update()
    {
        //現在の回転地からトランスフォームを回転
        transform.Rotate(
            deltaPitch * pitchAngularSpeed * Time.deltaTime,
            deltaYaw * yawAngularSpeed * Time.deltaTime,
            -deltaRoll * rollAngularSpeed * Time.deltaTime,Space.Self);
    }
}
