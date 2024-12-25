using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
    }

    //16進数（hexadecimal）で色を決める
    public void SetColorWithHexa(string hexaColor)
    {
        Color color = new Color();
        if(ColorUtility.TryParseHtmlString(hexaColor , out color))
        {
            image.color = color;
        }
        else 
        {
            Debug.LogWarning($"hexaColor({hexaColor})の変換に失敗");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
