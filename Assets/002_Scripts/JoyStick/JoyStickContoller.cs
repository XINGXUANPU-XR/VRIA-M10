using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JoyStickContoller : MonoBehaviour,IDragHandler,IEndDragHandler
{

    //ハンドルが移動できる距離
    [SerializeField]
    float maxDistance;
    //ハンドルの位置情報
    [SerializeField]
    Transform joystickHandle;

    //ジョイスティックの入力値を伝えるイベント
    public UnityEvent<Vector2> JoystickOutput;

    public void OnDrag(PointerEventData eventData)
    {
        joystickHandle.localPosition = GetPosition(eventData.position);
        //入力の度合いを0~1のスクールに計算する
        Vector2 inputRatio = joystickHandle.localPosition / maxDistance;
        //イベント送信
        JoystickOutput?.Invoke(inputRatio);
    }

    Vector3 GetPosition(Vector3 userInput)
    {
        //ユーザー入力がゲームオブジェクトに対してどこにあるか計算
        Vector3 dir = userInput - transform.position;
        //入力位置がハンドルの移動限界よりも速い場合、補正する
        if(maxDistance * maxDistance < Vector3.SqrMagnitude(dir))
        {
            dir = dir.normalized * maxDistance;
        }
        return dir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //ハンドルの位置をリセット
        joystickHandle.localPosition = Vector3.zero;
        //イベントを送信する
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
