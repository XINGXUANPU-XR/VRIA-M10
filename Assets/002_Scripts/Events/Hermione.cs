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
        //Rita�N���X��PublishNews,PublishGossip �C�x���g��WatchNews���\�b�h��o�^����
        //�i���T�u�X�N���C�u����A�Ƃ����j
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
        Debug.Log("�n�[�}�C�I�j�[�͑S�Č��܂�");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
