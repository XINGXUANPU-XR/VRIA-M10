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
        //Rita�N���X��PublishNews�C�x���g��WatchNews���\�b�h��o�^����
        //�i���T�u�X�N���C�u����A�Ƃ����j
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
        Debug.Log("�p���[�̓j���[�X�����܂�");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
