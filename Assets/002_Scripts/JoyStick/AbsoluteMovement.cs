using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsoluteMovement : MonoBehaviour
{

    public float speed = 1;
    //ゲームオブジェクトから取得した現在の向き
    public Vector3 currentDirection;

    //v.x＝cd.x、v.y＝cd.yに方向を設定
    public void MoveDirectionXZ(Vector2 moveValue)
    {
        //Vector2の入力値をVector3にプロット
        currentDirection = new Vector3(moveValue.x, 0, moveValue.y);
    }

    //v.x=cd.x, v.y=cd.zに方向を設定
    public void MoveDirectionXY(Vector2 moveValue)
    {
        //Vector2の入力値をVector3にプロット
        currentDirection = new Vector3(moveValue.x, moveValue.y, 0);
    }

    public void Update()
    {
        //トランスフォームを現在の向きの方へ設定されたスピードで移動
        transform.position += currentDirection * speed * Time.deltaTime;
    }
}
