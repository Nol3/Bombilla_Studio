using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLoads : MonoBehaviour
{
    public TextMeshProUGUI Obj_Text_Top;
    public TextMeshProUGUI Obj_Text_Bot;
    public Image MemeSprite;
    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log(PlayerPrefs.GetString("top_text"));
        Debug.Log(PlayerPrefs.GetString("bot_text"));*/
        Debug.Log(PlayerPrefs.GetString("meme_name"));

        Obj_Text_Top.text = PlayerPrefs.GetString("top_text");
        Obj_Text_Bot.text = PlayerPrefs.GetString("bot_text");
        string MemeName = PlayerPrefs.GetString("meme_name");
        Sprite loadedImage = Resources.Load<Sprite>(MemeName);
        MemeSprite.sprite = loadedImage;

    }
}
