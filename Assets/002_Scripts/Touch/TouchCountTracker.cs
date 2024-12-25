using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchCountTracker : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI touchCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ʂɃ^�b�`���Ă���w�̖{����\������
        touchCountText.text = Input.touchCount.ToString();
    }
}
