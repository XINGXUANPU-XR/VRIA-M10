using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerSwipeDetection : MonoBehaviour
{

    //トラッキングする指のfingerID
    [SerializeField]
    int trackedFingerID;

    //DragSwopeDetectionから引用
    //スワイプの許容時間
    [SerializeField]
    float duration = 0.25f;
    [SerializeField]
    float theshold = 200f;

    public UnityEvent OnSwipeUp;
    public UnityEvent OnSwipeDown;
    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;

    //スワイプの開始位置
    Vector2 initialPosition;
    //スワイプの開始時間
    float initialTIme;

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
            if(touch.fingerId == trackedFingerID)
            {
                //fingerIDが一致したので処理を行い、ループを終了する
                //不要：transform.position = touch.position
                ProcessPhase(touch);
                break;
            }
        }
    }

    void ProcessPhase(Touch touch)
    {

        //TouchPhase毎に処理する
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

            //スワイプの開始（初期化）
            case TouchPhase.Began:
            case TouchPhase.Stationary:
                initialPosition = touch.position;
                initialTIme = Time.time;
                break;
            //不要case TOuchPhase.Moved:
            //  Debug.Log($"TOuchPhase:{phase}");
            //  OnMoved?.Invoke();
            //  break;

            //スワイプの終了（判定）
            case TouchPhase.Ended:
            //      Debug.Log($"TouchPhase:{phase}");
            //      OnEnded?.Invoke();
                if(Time.time - initialTIme < duration)
                {
                    ValidateSwipe(touch);
                }
                break;
            //不要case TOuchPhase.Canceled:
            //      Debug.Log($"TouchPhase:{phase}");
            //      OnCancelled?.Invoke();
            //      break;
        }
    }

    void ValidateSwipe(Touch touch)
    {
        //スワイプのベクトルを計算する
        Vector2 delta = touch.position - initialPosition;

        //スワイプ距離を判定する
        //DragSwipeDetection.CheckSwipeから引用
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
