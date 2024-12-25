using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{

    //表示するモデルのリスト
    [SerializeField]
    List<GameObject> models;

    //表示中のモデル番号
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //リストのゲームオブジェクトを一旦全てオフにする
        foreach(GameObject model in models)
        {
            model.gameObject.SetActive(false);
        }

        //最初のモデル表示
        ChangeModel(0);
    }

    //<summary>
    //現在のモデルを非表示にし、新しいモデルを表示する
    //</summar>
    public void ChangeModel(int newIndex)
    {
        //現在のモデルを非表示にする
        models[currentIndex].SetActive(false);
        //新しいモデルを表示する
        models[newIndex].SetActive(true);

        //モデル番号の更新
        currentIndex = newIndex;
    }

    public void NextModel()
    {
        int nextIndex = currentIndex + 1;

        //nextIndexがリストの要素数以上の数字になるなら
        if(models.Count <= nextIndex)
        {
            nextIndex = 0;//リストの先頭に戻る
        }

        ChangeModel(nextIndex);
    }

    public void PreviousModel()
    {
        int previousIndex = currentIndex - 1;

        //previousIndex が0より小さい数字になるなら
        if(previousIndex < 0)
        {
            previousIndex = models.Count - 1;//リストの最後尾に戻る
        }

        ChangeModel(previousIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
