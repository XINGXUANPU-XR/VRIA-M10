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


    //Awake�̓A�v���P�[�V�����N�����A�ŏ��ɌĂяo�����C�x���g�֐�
    //*Awaker��Start������ɌĂяo�����

    private void Awake()
    {
        //Instance��null(���ݒ�)�̏ꍇ
        if(!Instance)                   //if(Instance == false)�Ɠ���
        {
            Instance = this;            //Instance�Ɏ������g��ݒ肷��
            DontDestroyOnLoad(this);    //�V�[�����܂������Ă���������Ȃ��Ȃ�
        }
        //Instance���ݒ�ς݂��A�ʂ̃I�u�W�F�N�g�̏ꍇ
        else if(Instance != this)
        {
            Destroy(this);              //�ォ��o�Ă������m�ɂ͏����Ă��炤
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
