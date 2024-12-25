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

    //16�i���ihexadecimal�j�ŐF�����߂�
    public void SetColorWithHexa(string hexaColor)
    {
        Color color = new Color();
        if(ColorUtility.TryParseHtmlString(hexaColor , out color))
        {
            image.color = color;
        }
        else 
        {
            Debug.LogWarning($"hexaColor({hexaColor})�̕ϊ��Ɏ��s");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
