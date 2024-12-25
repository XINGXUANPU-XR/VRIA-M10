using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermione : MonoBehaviour
{
    [SerializeField]
    Rita rita;

    // Start is called before the first frame update
    void Start()
    {
        //RitaクラスのPublishNews,PublishGossip イベントにWatchNewsメソッドを登録する
        //（＝サブスクライブする、という）
        //rita.PublishNews.AddListener(WatchAll);
        //rita.PublishGossip.AddListener(WatchAll);

    }

    void OnEnable()
    {
        rita.PublishNews.AddListener(WatchAll);
        rita.PublishGossip.AddListener(WatchAll);
    }

    void OnDisable()
    {
        rita.PublishNews.RemoveListener(WatchAll);
        rita.PublishGossip.RemoveListener(WatchAll);
    }

    public void WatchAll()
    {
        Debug.Log("ハーマイオニーは全て見ます");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
