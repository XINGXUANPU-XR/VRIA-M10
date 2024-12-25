using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//UnityEvent�ɕK�v
using UnityEngine.InputSystem;

public class Rita : MonoBehaviour
{

    public UnityEvent PublishNews;
    public UnityEvent PublishGossip;

    //String�^�̈��������UnityEvent�i�n��������͎l�܂Łj
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
            PublishNews.Invoke();//Invoke���\�b�h�ŃC�x���g��Publish����
            PublishGossip.Invoke();//Invoke���\�b�h�ŃC�x���g��Publish����
            PublishName.Invoke(nameToPublish);
        }
    }
}
