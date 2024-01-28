using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image MainMeme;
    bool selected;
    // Start is called before the first frame update

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (!selected)
        {
            //Output to console the GameObject's name and the following message
            Image ThisMeme = this.gameObject.GetComponent<Image>();
            MainMeme.sprite = ThisMeme.sprite;
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (!selected)
        {
            MainMeme.sprite = null;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        selected = true;
        Image ThisMeme = this.gameObject.GetComponent<Image>();
        MainMeme.sprite = ThisMeme.sprite;
    }
}
