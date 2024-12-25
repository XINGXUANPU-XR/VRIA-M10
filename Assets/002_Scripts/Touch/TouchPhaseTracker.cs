using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TouchPhaseTracker : MonoBehaviour
{

    //トラッキングする指のfingerID
    [SerializeField]
    int fingerID;

    //各TouchPhaseに対応したイベント
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
        //このフレームでタッチしている指の本数を取得する
        int touchCount = Input.touchCount;
        //タッチされている指の本数分ループして、それらのタッチ情報をチェック
        for(int i = 0;i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            //入力されたfingerIDとトラッキングする指のfingerIDが一致していたら
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
        //TouchPhase毎にインベントをInvokeする
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
