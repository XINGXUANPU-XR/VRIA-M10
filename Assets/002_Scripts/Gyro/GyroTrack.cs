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
        //システム情報でジャイロ機能がサポートされていれば
        if(SystemInfo.supportsGyroscope)
        {
            //ジャイロ機能を有効にする
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //attitude:姿勢
        gyroscopeText.text = $"Input.gyro.sttitude:{gyroscope.attitude}";
        accelerometerText.text = $"Input.gyro.userAcceleration:{gyroscope.userAcceleration}";
    }
}
