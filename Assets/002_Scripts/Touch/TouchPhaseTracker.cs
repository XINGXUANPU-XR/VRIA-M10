using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TouchPhaseTracker : MonoBehaviour
{

    //�g���b�L���O����w��fingerID
    [SerializeField]
    int fingerID;

    //�eTouchPhase�ɑΉ������C�x���g
    public UnityEvent OnBegan;
    public UnityEvent OnStationary;
    public UnityEvent OnMoved;
    public UnityEvent OnEnded;
    public UnityEvent OnCancelled;
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
            if(touch.fingerId == fingerID)
            {
                transform.position = touch.position;
                ProcessPhase(touch.phase);
                break;
            }
           
        }
    }

    void ProcessPhase(TouchPhase phase)
    {
        //TouchPhase���ɃC���x���g��Invoke����
        switch(phase)
        {
            case TouchPhase.Began:
                Debug.Log($"TouchPhase:{phase}");
                OnBegan?.Invoke();
                break;

            case TouchPhase.Stationary:
                Debug.Log($"TouchPhase:{phase}");
                OnStationary?.Invoke();
                break;

            case TouchPhase.Moved:
                Debug.Log($"TouchPhase:{phase}");
                OnMoved?.Invoke();
                break;

            case TouchPhase.Ended:
                Debug.Log($"TouchPhase:{phase}");
                OnEnded?.Invoke();
                break;

            case TouchPhase.Canceled:
                Debug.Log($"TouchPhase:{phase}");
                OnCancelled?.Invoke();
                break;


        }
    }
}
