using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMovement : MonoBehaviour
{

    //各値に対応する速度、naturalSpeedは入力の影響を受けない
    public float strafeSpeed, forwardSpeed, naturalSpeed;

    //現在の移動方向
    private Vector2 inputDirection;

    //入力の向きを設定
    public void SetDirectionInput(Vector2 moveValue)
    {
        inputDirection = moveValue;
    }

    //入力と速度に基づき方向を計算
    public Vector3 CalculateDirection()
    {
        return (transform.forward * inputDirection.y * forwardSpeed +
                transform.right * inputDirection.x * strafeSpeed);
    }

    public void Update() 
    {
        //現在の回転値からトランスフォームを回転
        Vector3 direction = CalculateDirection() + transform.forward * naturalSpeed;

        //プレイヤーに移動を加える（プレイヤーを動かす）
        transform.position += direction * Time.deltaTime;
    }
    // Start is called before the first frame update

}
