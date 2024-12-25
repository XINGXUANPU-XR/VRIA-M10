using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTool : MonoBehaviour
{

    void OnEnable()
    {
        PlayerManager.Instance.AgeUpdate.AddListener(PrintPlayerAge);
    }

    void OnDisable()
    {
        PlayerManager.Instance.AgeUpdate.RemoveListener(PrintPlayerAge);
    }

    public void PrintPlayerAge()
    {
        //PlayerManagerのPlayerAgeを表示する
        Debug.Log(PlayerManager.Instance.PlayerAge);

        //従来(下記)のように、UnityEditorからの参照設定が不要で
        //アクセスすることができる
        //[SerializaField]
        //PlayerManager playerManager;
    }

    //0~100までの整数をランダムに生成して、PlayerAgeに設定する
    public void ChangePlayerAge()
    {
        int newAge = (int)Random.Range(0.0f, 100.0f);
        Debug.Log($"ランダムの整数{newAge}を生成");
        PlayerManager.Instance.PlayerAge = newAge;
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
