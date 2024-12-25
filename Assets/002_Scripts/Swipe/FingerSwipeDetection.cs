using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerSwipeDetection : MonoBehaviour
{

    //�g���b�L���O����w��fingerID
    [SerializeField]
    int trackedFingerID;

    //DragSwopeDetection������p
    //�X���C�v�̋��e����
    [SerializeField]
    float duration = 0.25f;
    [SerializeField]
    float theshold = 200f;

    public UnityEvent OnSwipeUp;
    public UnityEvent OnSwipeDown;
    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;

    //�X���C�v�̊J�n�ʒu
    Vector2 initialPosition;
    //�X���C�v�̊J�n����
    float initialTIme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���̃t���[���Ń^�b�`���Ă���w�̖{�����擾����
        int touchCount = Input.touchCount;
        //�^�b�`����Ă���w�̖{�������[�v���āA�����̃^�b�`�����`�F�b�N
        for(int i = 0;i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            //���͂��ꂽfingerID�ƃg���b�L���O����w��fingerID����v���Ă�����
            if(touch.fingerId == trackedFingerID)
            {
                //fingerID����v�����̂ŏ������s���A���[�v���I������
                //�s�v�Ftransform.position = touch.position
                ProcessPhase(touch);
                break;
            }
        }
    }

    void ProcessPhase(Touch touch)
    {

        //TouchPhase���ɏ�������
        //switch(phase)
        switch(touch.phase)
        {
            /*
            case TouchPhase.Began:
                Debug.Log($"TouchPhase:{phase}");
                OnBegan?.Invoke();
                break;
            case TouchPhase.Stationary:
                Debug,Log($"TouchPhase:{phase}");
                OnStationary?.Invoke();
                break;
            */

            //�X���C�v�̊J�n�i�������j
            case TouchPhase.Began:
            case TouchPhase.Stationary:
                initialPosition = touch.position;
                initialTIme = Time.time;
                break;
            //�s�vcase TOuchPhase.Moved:
            //  Debug.Log($"TOuchPhase:{phase}");
            //  OnMoved?.Invoke();
            //  break;

            //�X���C�v�̏I���i����j
            case TouchPhase.Ended:
            //      Debug.Log($"TouchPhase:{phase}");
            //      OnEnded?.Invoke();
                if(Time.time - initialTIme < duration)
                {
                    ValidateSwipe(touch);
                }
                break;
            //�s�vcase TOuchPhase.Canceled:
            //      Debug.Log($"TouchPhase:{phase}");
            //      OnCancelled?.Invoke();
            //      break;
        }
    }

    void ValidateSwipe(Touch touch)
    {
        //�X���C�v�̃x�N�g�����v�Z����
        Vector2 delta = touch.position - initialPosition;

        //�X���C�v�����𔻒肷��
        //DragSwipeDetection.CheckSwipe������p
        if((theshold * theshold) < delta.sqrMagnitude)
        {
            if(Mathf.Abs(delta.x) < Mathf.Abs(delta.y))
            {
                if(0 < delta.y)
                {
                    OnSwipeUp?.Invoke();
                }
                else
                {
                    OnSwipeDown?.Invoke();
                }
            }
            else
            {
                if(0 < delta.x)
                {
                    OnSwipeRight?.Invoke();
                }
                else
                {
                    OnSwipeLeft?.Invoke();
                }
            }
        }
    }
}
