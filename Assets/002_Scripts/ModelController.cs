using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{

    //�\�����郂�f���̃��X�g
    [SerializeField]
    List<GameObject> models;

    //�\�����̃��f���ԍ�
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //���X�g�̃Q�[���I�u�W�F�N�g����U�S�ăI�t�ɂ���
        foreach(GameObject model in models)
        {
            model.gameObject.SetActive(false);
        }

        //�ŏ��̃��f���\��
        ChangeModel(0);
    }

    //<summary>
    //���݂̃��f�����\���ɂ��A�V�������f����\������
    //</summar>
    public void ChangeModel(int newIndex)
    {
        //���݂̃��f�����\���ɂ���
        models[currentIndex].SetActive(false);
        //�V�������f����\������
        models[newIndex].SetActive(true);

        //���f���ԍ��̍X�V
        currentIndex = newIndex;
    }

    public void NextModel()
    {
        int nextIndex = currentIndex + 1;

        //nextIndex�����X�g�̗v�f���ȏ�̐����ɂȂ�Ȃ�
        if(models.Count <= nextIndex)
        {
            nextIndex = 0;//���X�g�̐擪�ɖ߂�
        }

        ChangeModel(nextIndex);
    }

    public void PreviousModel()
    {
        int previousIndex = currentIndex - 1;

        //previousIndex ��0��菬���������ɂȂ�Ȃ�
        if(previousIndex < 0)
        {
            previousIndex = models.Count - 1;//���X�g�̍Ō���ɖ߂�
        }

        ChangeModel(previousIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
