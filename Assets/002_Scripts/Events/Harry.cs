using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : MonoBehaviour
{

    [SerializeField]
    Rita rita;

    // Start is called before the first frame update
    void Start()
    {
        //RitaクラスのPublishNewsイベントにWatchNewsメソッドを登録する
        //（＝サブスクライブする、という）
        //rita.PublishNews.AddListener(WatchNews);
    }

    void OnEnable()
    {
        rita.PublishNews.AddListener (WatchNews);
    }

    void OnDisable()
    {
        rita.PublishNews.RemoveListener(WatchNews);
    }
    public void WatchNews()
    {
        Debug.Log("パリーはニュースを見ます");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
