using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JoyStickContoller : MonoBehaviour,IDragHandler,IEndDragHandler
{

    //�n���h�����ړ��ł��鋗��
    [SerializeField]
    float maxDistance;
    //�n���h���̈ʒu���
    [SerializeField]
    Transform joystickHandle;

    //�W���C�X�e�B�b�N�̓��͒l��`����C�x���g
    public UnityEvent<Vector2> JoystickOutput;

    public void OnDrag(PointerEventData eventData)
    {
        joystickHandle.localPosition = GetPosition(eventData.position);
        //���͂̓x������0~1�̃X�N�[���Ɍv�Z����
        Vector2 inputRatio = joystickHandle.localPosition / maxDistance;
        //�C�x���g���M
        JoystickOutput?.Invoke(inputRatio);
    }

    Vector3 GetPosition(Vector3 userInput)
    {
        //���[�U�[���͂��Q�[���I�u�W�F�N�g�ɑ΂��Ăǂ��ɂ��邩�v�Z
        Vector3 dir = userInput - transform.position;
        //���͈ʒu���n���h���̈ړ����E���������ꍇ�A�␳����
        if(maxDistance * maxDistance < Vector3.SqrMagnitude(dir))
        {
            dir = dir.normalized * maxDistance;
        }
        return dir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�n���h���̈ʒu�����Z�b�g
        joystickHandle.localPosition = Vector3.zero;
        //�C�x���g�𑗐M����
        JoystickOutput?.Invoke(Vector2.zero);
    }

    public void DebugJoyStickInput(Vector2 input)
    {
        Debug.Log(input);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
