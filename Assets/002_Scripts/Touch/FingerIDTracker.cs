using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerIDTracker : MonoBehaviour
{

    //�g���b�L���O����w��fingerID
    [SerializeField]
    int fingerID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���̃t���[���Ń^�b�`���Ă���w�̖{�����擾����
        int touchCount = Input.touchCount;
        //�^�b�`����Ă���w�̖{�������[�v���āA�����̃^�b�`�����`�F�b�N
        for(int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            //���͂��ꂽfingerID�ƃg���b�L���O����w��fingerID����v���Ă�����
            if(touch.fingerId == fingerID)
            {
                //fingerID����v�����ŏ������s���A���[�v���I������
                transform.position = touch.position;
                break;
            }
        }
    }
}
