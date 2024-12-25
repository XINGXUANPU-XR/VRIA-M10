using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //��]���x�̊��x�A60���ǂ�
    public float pitchAngularSpeed, rollAngularSpeed, yawAngularSpeed;

    //���ݎZ�o����Ă���1�b������̉�]���x
    private float deltaRoll, deltaPitch, deltaYaw;

    //v.x = cd.x , v.y = cd.y�ɕ��@��ݒ�
    public void DeltaAngles(Vector2 moveValue)
    {
        deltaRoll = moveValue.x;
        deltaPitch = moveValue.y;
    }

    //v.x = cd.x , v.y = cd.z�ɕ��@��ݒ�
    public void DeltaAngleYaw(Vector2 moveValue)
    {
        deltaYaw = moveValue.x;
    }

    public void Update()
    {
        //���݂̉�]�n����g�����X�t�H�[������]
        transform.Rotate(
            deltaPitch * pitchAngularSpeed * Time.deltaTime,
            deltaYaw * yawAngularSpeed * Time.deltaTime,
            -deltaRoll * rollAngularSpeed * Time.deltaTime,Space.Self);
    }
}
