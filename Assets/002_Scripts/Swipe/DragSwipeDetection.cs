using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DragSwipeDetection : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //�X���C�v�̋��e����
    [SerializeField]
    float duration = 0.25f;

    [SerializeField]
    float theshold = 200.0f;

    public UnityEvent OnSwipeRight;
    public UnityEvent OnSwipeLeft;

    //�h���b�O�̊J�n����
    float startTime;
    //�h���b�O�̊J�n�ʒu�ƏI���ʒu�̍�
    Vector2 delta;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");

        //�h���b�O�J�n���Ԃ�������
        startTime = Time.time;
        //�h���b�O�̈ړ��ʂ�������
        delta = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        //�h���b�O�̈ړ��ʂ��X�V����
        delta += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");

        //�h���b�O�ɂ����������Ԃ𔻒肷��
        if (duration < Time.time - startTime)
        {
            //�X���C�v���e���Ԃ𒴂����̂ŏ������I��
            return;
        }
        //�h���b�O���������𔻒肷��i���E�̃X���C�v�Łj
        if(theshold < Mathf.Abs(delta.x))
        {
            if(0< delta.x)
            {
                //�E�ɃX���C�v
                Debug.Log("�E�ɃX���C�v");
                OnSwipeRight?.Invoke();
            }
            else
            {
                //���ɃX���C�v
                Debug.Log("���ɃX���C�v");
                OnSwipeLeft?.Invoke();
            }
        }
    }

    Vector2 CheckSwipe(Vector2 delta)
    {
        if((theshold * theshold) < delta.sqrMagnitude)
        {
            if(Mathf.Abs(delta.x) < Mathf.Abs(delta.y))
            {
                if(0 < delta.y)
                {
                    //��X���C�v
                    return Vector2.up;
                }
                else
                {
                    //���X���C�v
                    return Vector2.down;
                }
            }
            else
            {
                if (0 < delta.x)
                {
                    //�E�X���C�v
                    return Vector2.right;
                }
                else
                {
                    return Vector2.left;
                }
            }


        }
        
        return Vector2.zero;
    }
}
