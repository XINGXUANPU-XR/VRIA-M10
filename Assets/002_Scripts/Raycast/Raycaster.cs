using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{

    [SerializeField]
    Camera camera;                      //raycastの基準となるカメラ

    [SerializeField]
    float raycastDistance = 100.0f;     //raycastを行う距離

    [SerializeField]
    LayerMask targetLayer;              //raycastの対象レイヤー

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
        //mousePositionを起点にカメラからRayを飛ばす
        ray = camera.ScreenPointToRay(clickPosition);

        //Physics.Raycast():Rayを飛ばして、当たり判定を行う（戻る値：bool値）
        //QueryTriggerInteraction.Ignore:rayは「IS Trigger」名コライダーを無視する
        if(Physics.Raycast(ray,out hit,raycastDistance,targetLayer,
                            QueryTriggerInteraction.Ignore))
        {
            //HitDetectedイベントを発火。rayが当たった物体の名前を引数で渡す
            HitDetected?.Invoke(hit.transform.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
