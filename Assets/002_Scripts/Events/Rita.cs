using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//UnityEventに必要
using UnityEngine.InputSystem;

public class Rita : MonoBehaviour
{

    public UnityEvent PublishNews;
    public UnityEvent PublishGossip;

    //String型の引数を取るUnityEvent（渡せる引数は四つまで）
    public UnityEvent<string> PublishName;

    [SerializeField]
    string nameToPublish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            PublishNews.Invoke();//InvokeメソッドでイベントをPublishする
            PublishGossip.Invoke();//InvokeメソッドでイベントをPublishする
            PublishName.Invoke(nameToPublish);
        }
    }
}
