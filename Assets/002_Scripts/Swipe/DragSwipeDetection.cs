using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DragSwipeDetection : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //スワイプの許容時間
    [SerializeField]
    float duration = 0.25f;

    [SerializeField]
    float theshold = 200.0f;

    public UnityEvent OnSwipeRight;
    public UnityEvent OnSwipeLeft;

    //ドラッグの開始時間
    float startTime;
    //ドラッグの開始位置と終了位置の差
    Vector2 delta;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");

        //ドラッグ開始時間を初期化
        startTime = Time.time;
        //ドラッグの移動量を初期化
        delta = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        //ドラッグの移動量を更新する
        delta += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");

        //ドラッグにかかった時間を判定する
        if (duration < Time.time - startTime)
        {
            //スワイプ許容時間を超えたので処理を終了
            return;
        }
        //ドラッグした距離を判定する（左右のスワイプで）
        if(theshold < Mathf.Abs(delta.x))
        {
            if(0< delta.x)
            {
                //右にスワイプ
                Debug.Log("右にスワイプ");
                OnSwipeRight?.Invoke();
            }
            else
            {
                //左にスワイプ
                Debug.Log("左にスワイプ");
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
                    //上スワイプ
                    return Vector2.up;
                }
                else
                {
                    //下スワイプ
                    return Vector2.down;
                }
            }
            else
            {
                if (0 < delta.x)
                {
                    //右スワイプ
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
