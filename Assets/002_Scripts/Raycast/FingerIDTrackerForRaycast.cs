using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerIDTrackerForRaycast : MonoBehaviour
{

    [SerializeField]
    int fingerID;

    public UnityEvent<Vector3> TouchDetected;

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
                //fingerIDが一致したので処理を行い、ループを終了する
                transform.position = touch.position;
                TouchDetected?.Invoke(touch.position);
                break;
            }
        }
    }
}
