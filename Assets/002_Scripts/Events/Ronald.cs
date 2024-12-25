using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronald : MonoBehaviour
{

    [SerializeField]
    Rita rita;

    // Start is called before the first frame update
    void Start()
    {
        //RonaldはRitaのニュースに登録しない
        //rita.Publish.AddListener(WatchSports);
    }

    public void WatchSports()
    {
        Debug.Log("ロンはスポーツを見ます");
    }

    public void MatchName(string name)
    {
        Debug.Log($"ロンは{name}と叫んだ");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
