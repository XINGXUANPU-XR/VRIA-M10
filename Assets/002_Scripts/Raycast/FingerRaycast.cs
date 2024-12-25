using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRaycast : MonoBehaviour
{

    [SerializeField]
    Camera camera;

    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        if(camera == null)
        {
            camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        //mousePosition���N�_�ɃJ��������Ray���΂�
        ray = camera.ScreenPointToRay(Input.mousePosition);
        //ray �ƈ�v��������f�o�b�O�p�ɕ`�悷�鏈��
        //ray.origin�Fray�̍��{
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }

    //�K�v�Ȏ�����DrwaRay���Ăяo���������\�b�h
    public void DrwaPointToRay(Vector3 clickPosition)
    {
        //mousePosition���N�_�ɃJ��������Ray���΂�
        ray = camera.ScreenPointToRay(clickPosition);
        //ray�ƈ�v��������f�o�b�O�p�ɕ`�悷�鏈��
        //ray.origin:ray�̍��{
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

    }
}
