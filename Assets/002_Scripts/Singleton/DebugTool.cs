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
        //PlayerManager��PlayerAge��\������
        Debug.Log(PlayerManager.Instance.PlayerAge);

        //�]��(���L)�̂悤�ɁAUnityEditor����̎Q�Ɛݒ肪�s�v��
        //�A�N�Z�X���邱�Ƃ��ł���
        //[SerializaField]
        //PlayerManager playerManager;
    }

    //0~100�܂ł̐����������_���ɐ������āAPlayerAge�ɐݒ肷��
    public void ChangePlayerAge()
    {
        int newAge = (int)Random.Range(0.0f, 100.0f);
        Debug.Log($"�����_���̐���{newAge}�𐶐�");
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
