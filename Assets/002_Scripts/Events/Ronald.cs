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
        //Ronald��Rita�̃j���[�X�ɓo�^���Ȃ�
        //rita.Publish.AddListener(WatchSports);
    }

    public void WatchSports()
    {
        Debug.Log("�����̓X�|�[�c�����܂�");
    }

    public void MatchName(string name)
    {
        Debug.Log($"������{name}�Ƌ���");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
