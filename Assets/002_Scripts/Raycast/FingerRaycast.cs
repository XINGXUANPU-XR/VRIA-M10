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
        //mousePositionを起点にカメラからRayを飛ばす
        ray = camera.ScreenPointToRay(Input.mousePosition);
        //ray と一致する線をデバッグ用に描画する処理
        //ray.origin：rayの根本
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }

    //必要な時だけDrwaRayを呼び出したいメソッド
    public void DrwaPointToRay(Vector3 clickPosition)
    {
        //mousePositionを起点にカメラからRayを飛ばす
        ray = camera.ScreenPointToRay(clickPosition);
        //rayと一致する線をデバッグ用に描画する処理
        //ray.origin:rayの根本
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

    }
}
