using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image MainMeme;
    public GameObject Full;
    bool Selected;
    // Start is called before the first frame update

    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (!Full.gameObject.GetComponent<FulllManager>().Selected)
        {
            //Output to console the GameObject's name and the following message
            Image ThisMeme = this.gameObject.GetComponent<Image>();
            MainMeme.sprite = ThisMeme.sprite;
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (!Full.gameObject.GetComponent<FulllManager>().Selected)
        {
            MainMeme.sprite = null;
        }
    }

    public void Clicking()
    {
        Full.gameObject.GetComponent<FulllManager>().Selected = true;
        Image ThisMeme = this.gameObject.GetComponent<Image>();
        MainMeme.sprite = ThisMeme.sprite;
    }
}
