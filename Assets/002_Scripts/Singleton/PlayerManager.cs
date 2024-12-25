using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance { get; private set; }

    public UnityEvent NameUpdate;
    public UnityEvent AgeUpdate;
    public UnityEvent HPUpdate;

    string playerName;
    int playerAge;
    int playerHP;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value;
            NameUpdate?.Invoke();}
    }

    public int PlayerAge
    {
        get { return playerAge; }
        set 
        { 
            playerAge = value;
            AgeUpdate?.Invoke();
        }
    }

    public int PlayerHP
    {
        get { return playerHP; }
        set 
        {
            playerHP = value;
            HPUpdate?.Invoke();
        }
    }


    //Awakeはアプリケーション起動時、最初に呼び出されるイベント関数
    //*AwakerはStartよりも先に呼び出される

    private void Awake()
    {
        //Instanceがnull(未設定)の場合
        if(!Instance)                   //if(Instance == false)と同じ
        {
            Instance = this;            //Instanceに自分自身を設定する
            DontDestroyOnLoad(this);    //シーンをまたがっても消除されなくなる
        }
        //Instanceが設定済みかつ、別のオブジェクトの場合
        else if(Instance != this)
        {
            Destroy(this);              //後から出てきたモノには消えてもらう
        }
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
