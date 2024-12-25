using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GyroTrack : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI gyroscopeText;

    [SerializeField]
    TextMeshProUGUI accelerometerText;

    Gyroscope gyroscope;

    // Start is called before the first frame update
    void Start()
    {
        //�V�X�e�����ŃW���C���@�\���T�|�[�g����Ă����
        if(SystemInfo.supportsGyroscope)
        {
            //�W���C���@�\��L���ɂ���
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //attitude:�p��
        gyroscopeText.text = $"Input.gyro.sttitude:{gyroscope.attitude}";
        accelerometerText.text = $"Input.gyro.userAcceleration:{gyroscope.userAcceleration}";
    }
}
