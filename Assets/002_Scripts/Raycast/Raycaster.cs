using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{

    [SerializeField]
    Camera camera;                      //raycast�̊�ƂȂ�J����

    [SerializeField]
    float raycastDistance = 100.0f;     //raycast���s������

    [SerializeField]
    LayerMask targetLayer;              //raycast�̑Ώۃ��C���[

    public UnityEvent<string> HitDetected;

    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        if(camera == null)
        {
            camera = Camera.main;
        }
    }

    public void Raycast(Vector3 clickPosition)

    {
        //mousePosition���N�_�ɃJ��������Ray���΂�
        ray = camera.ScreenPointToRay(clickPosition);

        //Physics.Raycast():Ray���΂��āA�����蔻����s���i�߂�l�Fbool�l�j
        //QueryTriggerInteraction.Ignore:ray�́uIS Trigger�v���R���C�_�[�𖳎�����
        if(Physics.Raycast(ray,out hit,raycastDistance,targetLayer,
                            QueryTriggerInteraction.Ignore))
        {
            //HitDetected�C�x���g�𔭉΁Bray�������������̖̂��O�������œn��
            HitDetected?.Invoke(hit.transform.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
